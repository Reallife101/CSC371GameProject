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
    public LayerMask playerMask;
    [SerializeField]
    string groundName = "Ground";

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

        // Move Character
        // Adjust for camera angle
        Vector3 move = cam.transform.right * x + cam.transform.forward * z*(Mathf.Sqrt(2));
        move = new Vector3(move.x, 0f, move.z);

        // Check movement
        Vector3 moveCheck = transform.position + (move * movementSpeed * Time.deltaTime);

        RaycastHit hit;

        if(checkMove(moveCheck))
        {
            controller.Move(move * movementSpeed * Time.deltaTime);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public bool checkMove(Vector3 pos)
    {
        RaycastHit hit;

        if (Physics.Raycast(pos, Vector3.down, out hit, Mathf.Infinity, ~playerMask))
        {
            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == groundName)
            {
                return true;
            }
        }
        return false;
    }
}
