using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody pivotPoint;

    Rigidbody rb;
    SpringJoint springJoint;
    Camera mainCamera;

    Vector3 position;
    float width;
    float height;

    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //TouchPosHandler();
    }

    void TouchPosHandler()
    {
        if(rb == null) { return; }

        if (!Touchscreen.current.primaryTouch.IsPressed())
        {
            isMoving = false;
           // rb.isKinematic = false;
            return;
        }
        else
        {
            isMoving = true;
           // rb.isKinematic = true;
            Vector3 touchPos = new Vector3(Touchscreen.current.primaryTouch.position.ReadValue().x,
                                            Touchscreen.current.primaryTouch.position.ReadValue().y,
                                            mainCamera.nearClipPlane);
            Vector3 worldCoordinates = mainCamera.ScreenToWorldPoint(touchPos);
            worldCoordinates.y = 0.5f;
            rb.position = worldCoordinates;
        }
    }   
    
    void LaunchPlayer()
    {
        rb.isKinematic = false;
        rb = null;
    }

    
}
