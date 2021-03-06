using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] UIManager managerUI;
    [SerializeField] Pointer pointer;

    Rigidbody playerRb;
    Camera mainCamera;
    LineRenderer lineRenderer;
    Ball ball;

    bool isMoving;

    TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        playerRb = player.GetComponent<Rigidbody>();
        lineRenderer = player.GetComponent<LineRenderer>();
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (managerUI.IsOnPause())
        {
            playerRb.isKinematic = true;
        }

        if (isMoving)
        {
            playerRb.isKinematic = true;
            Move(touchControls.Touch.TouchPosition.ReadValue<Vector2>());
            pointer.FindAngle();
            DrawPointer();
        }
        else if (!isMoving && !managerUI.IsOnPause())
        {
            playerRb.isKinematic = false;
            CleanPointer();
        }
    }

    void StartTouch(InputAction.CallbackContext context)
    {
        if(!managerUI.IsOnPause())
        {
            isMoving = true;
        } 
    }
    void EndTouch(InputAction.CallbackContext context)
    {
        if(!managerUI.IsOnPause())
        {
            isMoving = false;
        } 
    }

    public void Move(Vector2 screenPosition)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane);
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(screenCoordinates);
        player.transform.position = new Vector3(worldPos.x, 0f, worldPos.z);
    }

    void DrawPointer()
    {
        ball = FindObjectOfType<Ball>();
        if (ball != null)
        {
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, ball.transform.position);
        }
    }

    void CleanPointer()
    {
        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, player.transform.position);
    }
}
