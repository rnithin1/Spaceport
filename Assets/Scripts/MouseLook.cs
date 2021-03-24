using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;

    private float xMousePos;
    private float yMousePos;
    private float smoothedMousePosX;
    private float smoothedMousePosY;

    private float currentLookingPosX;
    private float currentLookingPosY;


    void Start()
    {
        // lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
        yMousePos = Input.GetAxisRaw("Mouse Y");
    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        yMousePos *= sensitivity * smoothing;

        smoothedMousePosX = Mathf.Lerp(smoothedMousePosX, xMousePos, 1f / smoothing);
        smoothedMousePosY = Mathf.Lerp(smoothedMousePosY, xMousePos, 1f / smoothing);
    }

    void MovePlayer()
    {
        currentLookingPosX += smoothedMousePosX;
        currentLookingPosY += smoothedMousePosY;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPosX, transform.up) * Quaternion.AngleAxis(currentLookingPosY, transform.right);
    }
}
