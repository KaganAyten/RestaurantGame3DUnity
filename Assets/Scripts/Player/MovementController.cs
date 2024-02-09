using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;

    private Rigidbody rb;
    private Animator anim;

    private Vector3 input;
    private float mouseInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        GetInput();
        UpdateAnimations();
        RotateChar();
        
    }
    private void RotateChar()
    {
        if (Input.GetMouseButton(1))
        {
            mouseInput = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseInput * sensitivity);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void UpdateAnimations()
    {
        if (input != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
    private void GetInput()
    {
        input.z = Input.GetAxis("Vertical");
        input.x = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.TransformDirection(input)*speed*Time.fixedDeltaTime);
        //rb.velocity += ((transform.forward * input.z) + (transform.right * input.x))*speed; kayarak gitsin istiyorsan aç
    }
}
