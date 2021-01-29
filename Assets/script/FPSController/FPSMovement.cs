using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    float x;
    float z;
    public float speed = 12.0f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    Vector3 move;
    Vector3 velocity;
    public LayerMask groundMask;
    bool isGrounded;
    public bool ismenuopen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        if (ismenuopen == false)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown("escape") || ismenuopen == true)
        {
        //turn on the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (ismenuopen == false) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void SetIsMenuOpenFalse() {
        ismenuopen = false;
    }
}
