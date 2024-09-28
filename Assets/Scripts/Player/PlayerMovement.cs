using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;// built in unity character controller component
    private Vector3 playerVelocity;// the velocity of the players object
    public bool groundedPlayer { get; private set; }// for tracking if the player is touching the ground or not
    public float playerSpeed { get; set; } = 4.0f; //how much the players movement is multiplied by
    private float jumpHeight = 1.0f; //amount of force added to player upwards when initially jumping
    private float gravityValue = -9.81f;// gravity that pushes the player down while they're not grounded
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        groundedPlayer = controller.isGrounded;

        //stops the player moving down when they're touching the floor
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));// gets the direction based on input
        move = Vector3.ClampMagnitude(move, 1f);// clamps the magnitude incase the player makes a diagonal input for movement
        move = transform.TransformDirection(move);// changes direction based on rotation direction of the player object
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= 2f;
            Debug.Log("Running");
        }

        controller.Move(move * Time.deltaTime * playerSpeed);// moves the player using the character controller

        // changes the height position of the player based on gravity
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

