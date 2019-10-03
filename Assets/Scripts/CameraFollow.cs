using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Attach This To Main Camera")]
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    public GameObject[] playerObjects;
    public float baseYPosition;
    public float xOffset = 0;
    public float zOffset = 0;
    public float yOffset = 0;
    public float xVariable;
    public float zVariable;

    [Header("Fake Positions")]
    public float position1x;
    public float position2x;
    public float position3x;
    public float position4x;
    public float position1y;
    public float position2y;
    public float position3y;
    public float position4y;

    // Start is called before the first frame update
    void Start()
    {
        baseYPosition = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FakePositions();
        PlayerDistance();
        CameraMove();

    }

    public void FakePositions()
    {
        //player 1. x Axis
        if(playerObjects[0].activeInHierarchy== false)
        {
            position1x = xVariable;
        }
        if (playerObjects[0] .activeInHierarchy == true)
        {
            position1x = playerObjects[0].transform.position.x;
        }

        //player 2. x Axis
        if (playerObjects[1] .activeInHierarchy == false)
        {
            position2x = xVariable;
        }
        if (playerObjects[1] .activeInHierarchy == true)
        {
            position2x = playerObjects[1].transform.position.x;
        }

        //player 3. x Axis
        if (playerObjects[2] .activeInHierarchy == false)
        {
            position3x = xVariable;
        }
        if (playerObjects[2] .activeInHierarchy == true)
        {
            position3x = playerObjects[2].transform.position.x;
        }

        //player 4. x Axis
        if (playerObjects[3] .activeInHierarchy == false)
        {
            position4x = xVariable;
        }
        if (playerObjects[3] .activeInHierarchy == true)
        {
            position4x = playerObjects[3].transform.position.x;
        }

        //player 1. y Axis
        if (playerObjects[0] .activeInHierarchy == false)
        {
            position1y = zVariable;
        }
        if (playerObjects[0] .activeInHierarchy == true)
        {
            position1y = playerObjects[0].transform.position.z;
        }

        //player 2. y Axis
        if (playerObjects[1] .activeInHierarchy == false)
        {
            position2y = zVariable;
        }
        if (playerObjects[1] .activeInHierarchy == true)
        {
            position2y = playerObjects[1].transform.position.z;
        }

        //player 3. y Axis
        if (playerObjects[2] .activeInHierarchy == false)
        {
            position3y = zVariable;
        }
        if (playerObjects[2] .activeInHierarchy == true)
        {
            position3y = playerObjects[2].transform.position.z;
        }

        //player 4. y Axis
        if (playerObjects[3] .activeInHierarchy == false)
        {
            position4y = zVariable;
        }
        if (playerObjects[3] .activeInHierarchy == true)
        {
            position4y = playerObjects[3].transform.position.z;
        }
    }


    public void CameraMove()
    { 
        xVariable = (position1x + position2x + position3x + position4x) /4;
        zVariable = (position1y + position2y + position3y + position4y) / 4;
        
        Vector3 targetPosition = new Vector3(xVariable + xOffset, baseYPosition + yOffset , zVariable + zOffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void PlayerDistance()
    {
        if(playerObjects[0] .activeInHierarchy == false)
        {
            playerObjects[0].transform.position = playerObjects[1].transform.position;
        }
        if (playerObjects[1] .activeInHierarchy == false)
        {
            playerObjects[1].transform.position = playerObjects[0].transform.position;
        }

        float grouping1 = Vector3.Distance(playerObjects[0].transform.position, playerObjects[1].transform.position);
        float grouping2 = Vector3.Distance(playerObjects[2].transform.position, playerObjects[3].transform.position);
        yOffset = (grouping1 + grouping2) / 2;
    }
}
