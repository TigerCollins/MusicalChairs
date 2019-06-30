using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecifics : MonoBehaviour
{
    public int localPlayerID;
    public string playerName;
    public Color playerColor;

    private void Awake()
    {
        if (localPlayerID == 1 && PlayerPrefs.GetString("Player 1 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 1 Username");
        }

        if (localPlayerID == 2 && PlayerPrefs.GetString("Player 2 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 2 Username");
        }

        if (localPlayerID == 3 && PlayerPrefs.GetString("Player 3 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 3 Username");
        }

        if (localPlayerID == 4 && PlayerPrefs.GetString("Player 4 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 4 Username");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", playerColor);
        

        //rend.material.shader = Shader.Find("_Color");
        //rend.material.SetColor("_Color", Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
