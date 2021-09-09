using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.CountBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            DestroyBock();
        }
    }

    void DestroyBock()
    {
        Destroy(gameObject);
        levelManager.DecreaseBlocksNumber();
    }
}
