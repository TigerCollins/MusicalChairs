using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecifics : MonoBehaviour
{
    public int localPlayerID;
    public string playerName;
    public Color playerColor;
    public float strength;
    public float agility;
    public float defence;

    private void Awake()
    {
        if (localPlayerID == 1 && PlayerPrefs.GetString("Player 1 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 1 Username");
            agility = PlayerPrefs.GetFloat("Player 1 Agility");
            strength = PlayerPrefs.GetFloat("Player 1 Strength");
            defence = PlayerPrefs.GetFloat("Player 1 Defence");
        }

        if (localPlayerID == 2 && PlayerPrefs.GetString("Player 2 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 2 Username");
            agility = PlayerPrefs.GetFloat("Player 2 Agility");
            strength = PlayerPrefs.GetFloat("Player 2 Strength");
            defence = PlayerPrefs.GetFloat("Player 2 Defence");
        }

        if (localPlayerID == 3 && PlayerPrefs.GetString("Player 3 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 3 Username");
            agility = PlayerPrefs.GetFloat("Player 3 Agility");
            strength = PlayerPrefs.GetFloat("Player 3 Strength");
            defence = PlayerPrefs.GetFloat("Player 3 Defence");
        }

        if (localPlayerID == 4 && PlayerPrefs.GetString("Player 4 Username") != "")
        {
            playerName = PlayerPrefs.GetString("Player 4 Username");
            agility = PlayerPrefs.GetFloat("Player 4 Agility");
            strength = PlayerPrefs.GetFloat("Player 4 Strength");
            defence = PlayerPrefs.GetFloat("Player 4 Defence");
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
