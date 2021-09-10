using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;

    float ballSpawnDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
            levelManager.Invoke("CreateNewBall", ballSpawnDelay); 
        }
    }
}
