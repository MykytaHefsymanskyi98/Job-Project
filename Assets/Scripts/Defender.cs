using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    LevelManager levelManager;
    Ball ball;
    Rigidbody rb;

    float ballCreatingDelay = 1f;
    float ballSearchDelay = 1.2f;
    float moveSpeedDelta = 50f;


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        FindNewBall();
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveToBall();
    }

    void MoveToBall()
    { 
        if(ball == null) 
        { 
            Invoke("FindNewBall", ballSearchDelay); 
        }
        else
        {
            if (transform.position.x > ball.transform.position.x)
            {
                rb.velocity = new Vector3(-1 * moveSpeed * Time.deltaTime, 0f, 0f);
            }
            else 
            {
                rb.velocity = new Vector3(1f * moveSpeed * Time.deltaTime, 0f, 0f);
            }
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
            levelManager.Invoke("CreateNewBall", ballCreatingDelay);
            Invoke("FindNewBall", ballSearchDelay);
        }
    }

    public void IncreaseSpeed()
    {
        moveSpeed += moveSpeedDelta;
    }

    void FindNewBall()
    {
        ball = FindObjectOfType<Ball>();
        if(ball == null) 
        {
            Debug.Log("Ball can not be found"); 
        }
    }
}
