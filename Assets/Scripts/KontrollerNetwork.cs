using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class KontrollerNetwork : NetworkBehaviour
{
    [Header("References")]
    private Camera playercamera;
    private CharacterController CharacterController;

    public float wallkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpPower = 5f;
    public bool isRunning = false;
    public float gravitiy = 10f;
    public float lookSpeed = 2f;
    public float lookXLimit = 60f;
    private float RotationX;
    public float currentVerticalSpeed;
    public float currentHorizontalSpeed;
    public float moveDirectionUp;
    private Vector3 moveDirection = Vector3.zero;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner) return;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (isRunning)
        {
            currentVerticalSpeed = runSpeed * Input.GetAxis("Vertical");
            currentHorizontalSpeed = runSpeed * Input.GetAxis("Horizontal");

        }
        else
        {
            currentVerticalSpeed = wallkSpeed * Input.GetAxis("Vertical");
            currentHorizontalSpeed = wallkSpeed * Input.GetAxis("Horizontal");
        }

        moveDirection = forward * currentVerticalSpeed + right * currentHorizontalSpeed;



        if (CharacterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirectionUp = jumpPower;
            }

        }
        else
        {
            moveDirectionUp -= gravitiy * Time.deltaTime;
        }
        moveDirection.y = moveDirectionUp;


        CharacterController.Move(moveDirection * Time.deltaTime);
    }
}
