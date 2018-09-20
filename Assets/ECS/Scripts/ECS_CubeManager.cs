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
using Unity.Rendering;
using Unity.Mathematics;
using Unity.Collections;
using UnityEngine.UI;

// Initializing our Cubes as Entities and assigning necessary compenents.
public class ECS_CubeManager : MonoBehaviour {

    public int sizeOfSpawn = 1000;
    public GameObject ecsCube;

    public Text numberOfObjectsText;
    public int numberOfObjects = 0;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCubes();
        }
	}

    void SpawnCubes()
    {
        // What's basically happening:
        // We are creating an EnitityManager (or referencing one if already existing).
        // We are creating a NativeArray of Entities.
        // We are looping through those Entities and add (or set) Components (data) for the systems to work on.

        //Basically a Singleton. If it exists reference an EntityManager, if not create it.
        var entityManager = World.Active.GetOrCreateManager <EntityManager>();

        // NativeArrays allow the cubes to be accessed over different threads.
        NativeArray<Entity> cubes = new NativeArray<Entity>(sizeOfSpawn, Allocator.Temp);
        // Instantiating our cubes over the EntityManager.
        entityManager.Instantiate(ecsCube, cubes);

        for(int i = 0; i < sizeOfSpawn; i++)
        {
            // Here we add all needed Components to all of our newly created Cube Entities.
            entityManager.AddComponentData(cubes[i], new ECS_RotationSpeed { RotationValue = 0.5f });
            entityManager.AddComponentData(cubes[i], new ECS_MoveSpeed { MoveValue = 1.0f });

            // Kind of like a Vector3 but closer to the native. Easier for the hardware to read, leading to better performance.
            // Calculating a random Position.
            float3 startingPos = new float3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f));

            entityManager.SetComponentData(cubes[i], new Position { Value = startingPos });
        }

        // Important for all Native Containers as to not leak memory. -> See Allocation types.
        // If we don't dispose we'll get an error. -> See Dispose Sentinel Safety System.
        cubes.Dispose();

        numberOfObjects += sizeOfSpawn;
        numberOfObjectsText.text = "Number of Objects: " + numberOfObjects.ToString();
    }
}
