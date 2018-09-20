using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    private float moveSpeed;
    private float rotationSpeed;

    private void Start()
    {
        moveSpeed = Random.Range(0.1f, 0.2f);
        rotationSpeed = Random.Range(0.1f, 2f);
    }

    void Update () {
		
        transform.position += Vector3.down * moveSpeed;
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.up);
	}
}
