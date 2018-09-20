using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour {
    
    public int sizeOfSpawn = 1000;
    public GameObject cube;

    public Text numberOfObjectsText;
    public int numberOfObjects = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        for(int i = 0; i < sizeOfSpawn; i++)
        {
            float randomX = Random.Range(-100f, 100f);
            float randomY = Random.Range(-100f, 100f);
            float randomZ = Random.Range(-100f, 100f);

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            Instantiate(cube, spawnPosition, Quaternion.identity);
        }

        numberOfObjects += sizeOfSpawn;
        numberOfObjectsText.text = "Number of Objects: " + numberOfObjects.ToString();
    }


}
