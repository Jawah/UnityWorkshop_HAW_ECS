// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Mathematics;

// See ECS_CubeMoverSystem.cs for more comments.
// The same is happening but for the rotation.

public class ECS_CubeRotaterSystem  : JobComponentSystem {

    private struct CubeRotateJob : IJobProcessComponentData<ECS_RotationSpeed, Rotation>
    {
        public float deltaTime;

        public void Execute(ref ECS_RotationSpeed speed, ref Rotation rot)
        {
            // math is the new class which is way more performant than Unity Classics math functions.
            // Easier for the hardware to read, leading to better performance.
            // Here the rotation of the cubes is calculated.
            rot.Value = math.mul(math.normalize(rot.Value), quaternion.axisAngle(math.up(), speed.RotationValue * deltaTime));
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new CubeRotateJob
        {
            deltaTime = Time.deltaTime
        };
        
        return job.Schedule(this, inputDeps);
    }
}