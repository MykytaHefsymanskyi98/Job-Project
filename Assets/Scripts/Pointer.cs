using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] GameObject player;

    Ball ball;

    float angle;

    public void FindAngle()
    {
        ball = FindObjectOfType<Ball>();
        if(ball != null)
        {
            Vector3 targetDir = ball.transform.position - player.transform.position;
            angle = Vector3.Angle(targetDir, player.transform.forward);
            Debug.Log(angle);
            player.transform.Rotate(0f, angle, 0f);
        }
    }
}
