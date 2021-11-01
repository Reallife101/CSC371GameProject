using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Camera cam;
    private CharacterController controller;

    public float movementSpeed = 12.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    //Check ground variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        // Get Movement Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 24.0f;
        }
        else
        {
            movementSpeed = 12.0f;
        }

        // Move Character
        // Adjust for camera angle
        Vector3 move = cam.transform.right * x + cam.transform.forward * z*(Mathf.Sqrt(2));
        move = new Vector3(move.x, 0f, move.z);
        //Debug.Log(move);

        controller.Move(move * movementSpeed * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
