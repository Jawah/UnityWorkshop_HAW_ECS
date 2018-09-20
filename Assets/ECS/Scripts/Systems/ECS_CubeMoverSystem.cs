// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Entities;
using Unity.Transforms;
using System;

// Here we link the data(our Components) to the system.
// We need to derive from JobComponentSystem instead of MonoBehaviour
// as we want to use this script as a system and only as that.
public class ECS_CubeMoverSystem : JobComponentSystem {

    // Any Entity that has an ECS_MoveSpeed as well as a Position Component is data i want to process.
    // Position is build-in helper Component that Unity provides (in Unity.Transforms)
	private struct CubeMoveJob : IJobProcessComponentData<ECS_MoveSpeed, Position>
    {
        // Here we declare everything we need for the job that we don't have in a Component yet.
        // We'll use deltaTime for our cubes changing over TIME.
        public float deltaTime;

        // A job needs an Execeute function in which is defined how to act on the data.
        public void Execute(ref ECS_MoveSpeed speed, ref Position pos)
        {
            // Here I want to take my data i declared and process it.
            // This is how we process the data in the system over time.
            pos.Value.y -= speed.MoveValue * deltaTime;
        }
    }

    // Our JobHandle is handling our job and scheduling it 
    // (putting it in the Job Queue for the Worker Threads to grab).
    // We can pass other Jobs (through the JobHandle) our Job should be dependent on.
    // This one has no dependencies.
    protected override JobHandle OnUpdate(JobHandle inputDeps) 
    {
        // Declaring our Job.
        var job = new CubeMoveJob
        {
            // Here we should say which data we still need to pass that wasnt passed yet (deltaTime);
            deltaTime = Time.deltaTime
        };
        // Return the ability to schedule the job.
        // Dependencies can be passed but don't have to. In this example it makes no difference.
        // These jobs are parallelized on multiple threads through worker threads.
        return job.Schedule(this, inputDeps);
    }
}
