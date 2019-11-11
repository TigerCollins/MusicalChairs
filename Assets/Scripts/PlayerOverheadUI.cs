using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOverheadUI : MonoBehaviour
{
    public GameObject targetPlayerNode;
    public GameObject targetPlayer;
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerName = targetPlayer.GetComponent<PlayerSpecifics>().playerName;
        this.transform.GetComponent<TextMesh>().text = playerName.Replace(playerName, playerName + "\n");
    }

    // Update is called once per frame
    void Update()
    {
        //Should be attached to the node, not the actual player
        transform.position = targetPlayerNode.transform.position;
        
    }
}
