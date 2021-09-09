using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    Rigidbody rb;

    float moveSpeed = 500f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
