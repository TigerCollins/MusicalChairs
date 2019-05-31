using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Script References")]
    public GameLoop gameLoop;

    [Header("Core Movement Variables")]
    public float movementMultiplier;
    private float tempVerticalMovement;
    private float VerticalMovement;
    private float tempHorizontalMovement;
    private float HorizontalMovement;
    private float baseMovementMultiplier;
    public bool canSprint = true;
    public float sprintMultiplier;

    [Header("Vertical Movement Variables")]
    public float airMovementMultiplier;
    public bool hasJumped;
    public bool isGrounded;
    public bool canJump = true;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        //declare
        rb = GetComponent<Rigidbody>();

        //movement
        baseMovementMultiplier = movementMultiplier / 10;
        movementMultiplier = baseMovementMultiplier;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isGrounded == false)
        {
            hasJumped = false;
        }
        if (collision.gameObject.transform.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Chair")
        {
            Destroy(collision.gameObject);
            if (GameObject.FindGameObjectsWithTag("Chair").Length <= 1)
            {
                gameLoop.maxChairs -= 1;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerCoreMovement();
    }

    
    void PlayerCoreMovement()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && canJump == true && isGrounded == true)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            hasJumped = true;
        }

        //Horizontal and vertical movement
        if (hasJumped == false)
        {
            VerticalMovement = Input.GetAxisRaw("Vertical");
            HorizontalMovement = Input.GetAxisRaw("Horizontal");
            tempVerticalMovement = VerticalMovement;
            tempHorizontalMovement = HorizontalMovement;
        }
        
        if (hasJumped == true)
        {
            if(tempVerticalMovement != Input.GetAxisRaw("Vertical"))
            {
                VerticalMovement = tempVerticalMovement + (Input.GetAxisRaw("Vertical") * airMovementMultiplier);
            }
            
            if(tempHorizontalMovement != Input.GetAxisRaw("Horizontal"))
            {
                HorizontalMovement = tempHorizontalMovement + (Input.GetAxisRaw("Horizontal") * airMovementMultiplier);
            }
            
        }

        rb.position += new Vector3((HorizontalMovement * movementMultiplier), 0, (VerticalMovement * movementMultiplier));

        //Sprint
        if(canSprint == true && Keyboard.current.leftShiftKey.isPressed)
        {
            movementMultiplier = baseMovementMultiplier * sprintMultiplier;
        }

        if (Keyboard.current.leftShiftKey.wasReleasedThisFrame)
        {
            movementMultiplier = baseMovementMultiplier;
        }
    }
}
