using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Ball ball;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
         
    }
    private void FixedUpdate()
    {
        MoveToBall();
    }

    void MoveToBall()
    { 
        if(ball == null) { return; }
        if (transform.position.x > ball.transform.position.x)
        {
            rb.velocity = new Vector3(-0.1f * moveSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (transform.position.x < ball.transform.position.x)
        {
            rb.velocity = new Vector3(0.1f * moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
    }
}
