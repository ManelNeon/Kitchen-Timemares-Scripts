using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;

    [SerializeField] [Range(0.0f, 0.5f)] private float mouseSmoothTime = 0.03f;

    [SerializeField] private float mouseSensitivity = 3.5f;



    private float cameraCap;

    private Vector2 currentMouseDelta;

    private Vector2 currentMouseDeltaVelocity;

    void Update()
    {
        UpdateMouse();
    }

    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraCap -= currentMouseDelta.y * mouseSensitivity;

        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
}
