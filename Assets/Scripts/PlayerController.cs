using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public bool debug;

    [Header("Script References")]
    public GameLoop gameLoop;

    [Header("Chair Interactions")]
    public bool inChair;

    [Header("Player Rotation")]
    public float smooth = 5.0f;

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

    [Header("Interaction Variables")]
    public bool abilityActive = false;
    public float damageProtection;

    [Header("Combat Variables")]
    public PlayerController otherPlayer;
    public float raycastDistance = 3.5f;
    public float pushForce;

    [Header("Dash Variables")]
    public float maxDashTime = 1.0f;
    public float dashSpeed = 1.0f;
    public float dashStoppingSpeed = 0.1f;
    public float dashDistance = 4;

    private float currentDashTime;

    // Start is called before the first frame update
    void Start()
    {
        //declare
        rb = GetComponent<Rigidbody>();

        //movement
        baseMovementMultiplier = movementMultiplier / 10;
        movementMultiplier = baseMovementMultiplier;
        currentDashTime = maxDashTime;
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

        otherPlayer = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Chair")
        {
            Destroy(collision.gameObject);
            inChair = true;
            if (GameObject.FindGameObjectsWithTag("Chair").Length <= 1)
            {
                gameLoop.maxChairs -= 1;
            }
        }

        if (collision.transform.tag == "Player")
        {
            otherPlayer = collision.gameObject.GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inChair == false)
        {
            PlayerCoreMovement();
            PlayerLook();
            Combat();
            CoreAbility();
        }

    }

    private void Update()
    {


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
            if (tempVerticalMovement != Input.GetAxisRaw("Vertical"))
            {
                VerticalMovement = tempVerticalMovement + (Input.GetAxisRaw("Vertical") * airMovementMultiplier);
            }

            if (tempHorizontalMovement != Input.GetAxisRaw("Horizontal"))
            {
                HorizontalMovement = tempHorizontalMovement + (Input.GetAxisRaw("Horizontal") * airMovementMultiplier);
            }

        }

        rb.position += new Vector3((HorizontalMovement * movementMultiplier), 0, (VerticalMovement * movementMultiplier));

        //Sprint
        if (canSprint == true && Keyboard.current.leftShiftKey.isPressed)
        {
            movementMultiplier = baseMovementMultiplier * sprintMultiplier;
        }

        if (Keyboard.current.leftShiftKey.wasReleasedThisFrame)
        {
            movementMultiplier = baseMovementMultiplier;
        }
    }

    void PlayerLook()
    {

        if (HorizontalMovement != 0)
        {

        }

        if (HorizontalMovement < 0)
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

        if (HorizontalMovement > 0)
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

        if (VerticalMovement != 0)
        {

        }

        if (VerticalMovement < 0)
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

        if (VerticalMovement > 0)
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

    }

    void CoreAbility()
    {
        //DASH
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentDashTime = 0.0f;
        }
        if (currentDashTime < maxDashTime)
        {
            if (HorizontalMovement != 0 || VerticalMovement != 0)
            {
                rb.position += new Vector3(HorizontalMovement * dashDistance, 0, VerticalMovement * dashDistance);
            }
            else
            {
                rb.position += transform.forward * -dashDistance;
            }

            //moveDirection = transform.forward * dashDistance;
            currentDashTime += dashStoppingSpeed;
        }
        else
        {
            //moveDirection = Vector3.zero;
        }
    }

    void Combat()
    {
        //SPECIAL ATTACK
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, raycastDistance))
        {
            if (hit.transform.gameObject.GetComponent<PlayerController>() != null)
            {
                otherPlayer = hit.transform.gameObject.GetComponent<PlayerController>();

            }

            else
            {
                otherPlayer = null;
            }

            if (debug)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
        }

        else
        {
            if (debug)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * raycastDistance, Color.white);
                Debug.Log("Did not Hit");
            }
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * (pushForce / 2.5f));
            if (otherPlayer != null)
            {
                print("yo");
                Rigidbody rb = otherPlayer.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(pushForce, this.gameObject.transform.position, raycastDistance + 1, .1f);
                }
            }

        }
    }
}

