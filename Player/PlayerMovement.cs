using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Vector3 inputVector;
    private Vector3 movementVector;

    

    private float myGravity = -10f;

    private CharacterController mycc;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mycc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
    }



    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
        inputVector = Vector3.Lerp(inputVector, Vector3.zero, Time.deltaTime);
        movementVector = (inputVector * speed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        mycc.Move(movementVector * Time.deltaTime);
    }
}
