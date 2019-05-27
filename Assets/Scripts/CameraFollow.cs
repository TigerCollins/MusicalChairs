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

    // Start is called before the first frame update
    void Start()
    {
        baseYPosition = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerDistance();
        CameraMove();

    }

    public void CameraMove()
    { 
        float xVariable = (playerObjects[0].transform.position.x + playerObjects[1].transform.position.x + playerObjects[2].transform.position.x + playerObjects[3].transform.position.x)/4;
        float zVariable = (playerObjects[0].transform.position.z + playerObjects[1].transform.position.z + playerObjects[2].transform.position.z + playerObjects[3].transform.position.z) / 4;
        
        Vector3 targetPosition = new Vector3(xVariable + xOffset, baseYPosition + yOffset , zVariable + zOffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void PlayerDistance()
    {
        float grouping1 = Vector3.Distance(playerObjects[0].transform.position, playerObjects[1].transform.position);
        float grouping2 = Vector3.Distance(playerObjects[2].transform.position, playerObjects[3].transform.position);
        yOffset = (grouping1 + grouping2) / 2;
    }
}
