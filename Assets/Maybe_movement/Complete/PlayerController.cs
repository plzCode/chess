using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;

    public Transform cameraTransform; // 카메라 Transform
    public float mouseSensitivity = 2f; // 마우스 감도


    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    float verticalRotation = 0f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 수평 회전
        transform.Rotate(0, mouseX * mouseSensitivity, 0);

        // 수직 회전
        verticalRotation -= mouseY * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        if (characterController.isGrounded)
        {
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = jumpSpeed;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
}