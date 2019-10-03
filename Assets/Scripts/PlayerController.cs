using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public bool debug;
    public int playerID;

    [Header("Script References")]
    public GameLoop gameLoop;
    public PlayerSpecifics playerSpecifics;

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
    public float basePushBackCooldown = 3;
    public float pushBackCooldown;

    [Header("Dash Variables")]
    public float maxDashTime = 1.0f;
    public float baseDashCoolDown = 5;
    public float dashCooldown;
    public float dashSpeed = 1.0f;
    public float dashStoppingSpeed = 0.1f;
    public float dashDistance = 4;

    private float P1currentDashTime;
    private float P2currentDashTime;
    private float P3currentDashTime;
    private float P4currentDashTime;

    [Header("Local Multiplayer")]
    public GameObject player1Object;
    public GameObject player2Object;
    public GameObject player3Object;
    public GameObject player4Object;

    // Start is called before the first frame update
    void Start()
    {
        //declare
        rb = GetComponent<Rigidbody>();
        playerSpecifics = GetComponent<PlayerSpecifics>();

        //movement
        baseMovementMultiplier = movementMultiplier / 10;
        movementMultiplier = baseMovementMultiplier;

        dashCooldown = baseDashCoolDown;
        pushBackCooldown = basePushBackCooldown;

        PlayerSelection();
        playerID = playerSpecifics.localPlayerID;

        if (playerID == 1)
        {
            player1Object = this.gameObject;
        }

        if (playerID == 2)
        {
            player2Object = this.gameObject;
        }

        if (playerID == 3)
        {
            player3Object = this.gameObject;
        }

        if (playerID == 4)
        {
            player4Object = this.gameObject;
        }

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

        }

    }

    public void PlayerSelection()
    {
    }

    private void Update()
    {
        dashCooldown -= Time.deltaTime;
        pushBackCooldown -= Time.deltaTime;

    }

    void PlayerCoreMovement()
    {

        Jump();


        //Horizontal and vertical movement
        if (hasJumped == false)
        {
            VerticalMovement = Input.GetAxis("G" + playerSpecifics.localPlayerID + "Vertical");
            HorizontalMovement = Input.GetAxis("G" + playerSpecifics.localPlayerID + "Horizontal");
            tempVerticalMovement = VerticalMovement;
            tempHorizontalMovement = HorizontalMovement;
        }

        if (hasJumped == true)
        {
            if (tempVerticalMovement != Input.GetAxisRaw("G" + playerSpecifics.localPlayerID + "Vertical"))
            {
                VerticalMovement = tempVerticalMovement + (Input.GetAxisRaw("G" + playerSpecifics.localPlayerID + "Vertical") * airMovementMultiplier);
            }

            if (tempHorizontalMovement != Input.GetAxisRaw("G" + playerSpecifics.localPlayerID + "Horizontal"))
            {
                HorizontalMovement = tempHorizontalMovement + (Input.GetAxisRaw("G" + playerSpecifics.localPlayerID + "Horizontal") * airMovementMultiplier);
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


    void Jump()
    {
        //Jump
        if (Input.GetButtonDown("G1Jump") && canJump == true && isGrounded == true)
        {
            if (playerID == 1)
            {
                player1Object.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                player1Object.GetComponent<PlayerController>().hasJumped = true;
            }

        }

        if (Input.GetButtonDown("G2Jump") && canJump == true && isGrounded == true)
        {
            if (playerID == 2)
            {
                player2Object.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                player2Object.GetComponent<PlayerController>().hasJumped = true;
            }

        }

        if (Input.GetButtonDown("G3Jump") && canJump == true && isGrounded == true)
        {
            if (playerID == 3)
            {
                player3Object.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                player3Object.GetComponent<PlayerController>().hasJumped = true;
            }

        }

        if (Input.GetButtonDown("G4Jump") && canJump == true && isGrounded == true)
        {
            if (playerID == 4)
            {
                player4Object.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                player4Object.GetComponent<PlayerController>().hasJumped = true;
            }

        }
    }

    void PlayerLook()
    {
        Vector3 movement = new Vector3(HorizontalMovement, 0.0f, VerticalMovement);
        if (HorizontalMovement != 0 && VerticalMovement != 0)
        {

            transform.rotation = Quaternion.LookRotation(-movement);
        }


    }

    void CoreAbility()
    {
        //DASH
        if ( playerID == 1 && Input.GetButtonDown("G1Teleport") && P1currentDashTime >= maxDashTime && dashCooldown <= 0)
        {
            P1currentDashTime = 0.0f;
            if (HorizontalMovement != 0 || VerticalMovement != 0 && P1currentDashTime < maxDashTime)
            {
                player1Object.GetComponent<Rigidbody>().position += new Vector3(HorizontalMovement * dashDistance, 0, VerticalMovement * dashDistance);
            }
            else
            {
                player1Object.GetComponent<Rigidbody>().position += transform.forward * -dashDistance;
            }
            dashCooldown = baseDashCoolDown;
        }
        P1currentDashTime += dashStoppingSpeed;

        if (playerID == 2 && Input.GetButtonDown("G2Teleport") && P1currentDashTime >= maxDashTime && dashCooldown <= 0)
        {
            P2currentDashTime = 0.0f;
            if (HorizontalMovement != 0 || VerticalMovement != 0 && P2currentDashTime < maxDashTime)
            {
                player2Object.GetComponent<Rigidbody>().position += new Vector3(HorizontalMovement * dashDistance, 0, VerticalMovement * dashDistance);
            }
            else
            {
                player2Object.GetComponent<Rigidbody>().position += transform.forward * -dashDistance;
            }
            dashCooldown = baseDashCoolDown;
        }
        P2currentDashTime += dashStoppingSpeed;

        if (playerID == 3 && Input.GetButtonDown("G1Teleport") && P1currentDashTime >= maxDashTime && dashCooldown <= 0)
        {
            P1currentDashTime = 0.0f;
            if (HorizontalMovement != 0 || VerticalMovement != 0 && P3currentDashTime < maxDashTime)
            {
                player3Object.GetComponent<Rigidbody>().position += new Vector3(HorizontalMovement * dashDistance, 0, VerticalMovement * dashDistance);
            }
            else
            {
                player3Object.GetComponent<Rigidbody>().position += transform.forward * -dashDistance;
            }
            dashCooldown = baseDashCoolDown;
        }
        P3currentDashTime += dashStoppingSpeed;

        if (playerID == 4 && Input.GetButtonDown("G4Teleport") && P4currentDashTime >= maxDashTime && dashCooldown <= 0)
        {
            P1currentDashTime = 0.0f;
            if (HorizontalMovement != 0 || VerticalMovement != 0 && P4currentDashTime < maxDashTime)
            {
                player4Object.GetComponent<Rigidbody>().position += new Vector3(HorizontalMovement * dashDistance, 0, VerticalMovement * dashDistance);
            }
            else
            {
                player4Object.GetComponent<Rigidbody>().position += transform.forward * -dashDistance;
            }
            dashCooldown = baseDashCoolDown;
        }
        P4currentDashTime += dashStoppingSpeed;

    }


    void HeavyAttack()
    {

    }
    void Combat()
    {
        //SPECIAL ATTACK
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance))
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
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }

            if (hit.transform.gameObject.GetComponent<PlayerController>() != null)
            {
                CoreAbility();
            }
        }

        else
        {
            CoreAbility();
            if (debug)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * raycastDistance, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        //Heavy Attack
        if (Input.GetButtonDown("G1HeavyAttack") && player1Object != null && pushBackCooldown <= 0)
        {
            if (player1Object != null && pushBackCooldown <= 0)
            {
                player1Object.GetComponent<Rigidbody>().AddForce(transform.forward * (pushForce / 2.5f));
                if (otherPlayer != null)
                {
                    Rigidbody rb = otherPlayer.gameObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(pushForce, player1Object.transform.position, raycastDistance + 1, .1f);
                    }
                }
                pushBackCooldown = basePushBackCooldown;
            }

        }

        if (Input.GetButtonDown("G2HeavyAttack") && player2Object != null && pushBackCooldown <= 0)
        {
            player2Object.GetComponent<Rigidbody>().AddForce(transform.forward * (pushForce / 2.5f));
            if (otherPlayer != null)
            {
                Rigidbody rb = otherPlayer.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(pushForce, player2Object.transform.position, raycastDistance + 1, .1f);
                }
            }
            pushBackCooldown = basePushBackCooldown;

        }

        if (Input.GetButtonDown("G3HeavyAttack") && player3Object != null && pushBackCooldown <= 0)
        {
            player3Object.GetComponent<Rigidbody>().AddForce(transform.forward * (pushForce / 2.5f));
            if (otherPlayer != null)
            {
                Rigidbody rb = otherPlayer.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(pushForce, player3Object.transform.position, raycastDistance + 1, .1f);
                }
            }
            pushBackCooldown = basePushBackCooldown;

        }

        if (Input.GetButtonDown("G4HeavyAttack") && player4Object != null && pushBackCooldown <= 0)
        {
            player4Object.GetComponent<Rigidbody>().AddForce(transform.forward * (pushForce / 2.5f));
            if (otherPlayer != null)
            {
                Rigidbody rb = otherPlayer.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(pushForce, player4Object.transform.position, raycastDistance + 1, .1f);
                }
            }
            pushBackCooldown = basePushBackCooldown;
        }
    }
}


