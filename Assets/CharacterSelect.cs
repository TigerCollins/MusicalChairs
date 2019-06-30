using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [Header("Visual Variables")]
    public Color playerOneColour;
    public Color playerTwoColour;
    public Color playerThreeColour;
    public Color playerFourColour;
    public Color CPUColour;

    public Image charSlotOne;
    public Image charSlotTwo;
    public Image charSlotThree;
    public Image charSlotFour;

    public GameObject addPlayerOne;
    public GameObject addPlayerTwo;
    public GameObject addPlayerThree;
    public GameObject addPlayerFour;

    public GameObject removePlayerOne;
    public GameObject removePlayerTwo;
    public GameObject removePlayerThree;
    public GameObject removePlayerFour;

    [Header("Real Player Bool Variables")]
    public bool playerOneReal = true;
    public bool playerTwoReal = false;
    public bool playerThreeReal = false;
    public bool playerFourReal = false;

    [Header("Player 1 Variables")]
    public string player1Name;
    public InputField player1Text;

    [Header("Player 2 Variables")]
    public string player2Name;
    public InputField player2Text;

    [Header("Player 3 Variables")]
    public string player3Name;
    public InputField player3Text;

    [Header("Player 4 Variables")]
    public string player4Name;
    public InputField player4Text;

    [Header("CPU Variables")]
    public string CPU1Name;
    public string CPU2Name;
    public string CPU3Name;
    public string CPU4Name;

    // Start is called before the first frame update
    void Start()
    {
        BoolCheck();
    }

    // Update is called once per frame
    void Update()
    {
        //BoolCheck();
    }

    public void BoolCheck()
    {
        //Player 1
        if(playerOneReal == true)
        {
            charSlotOne.color = playerOneColour;
            player1Text.text = player1Name;
            addPlayerOne.SetActive(false);
            removePlayerOne.SetActive(true);
        }

        else
        {
            charSlotOne.color = CPUColour;
            player1Text.text = CPU1Name;
            addPlayerOne.SetActive(true);
            removePlayerOne.SetActive(false);
        }

        //Player 2
        if (playerTwoReal == true)
        {
            charSlotTwo.color = playerTwoColour;
            player2Text.text = player2Name;
            addPlayerTwo.SetActive(false);
            removePlayerTwo.SetActive(true);
        }

        else
        {
            charSlotTwo.color = CPUColour;
            player2Text.text = CPU2Name;
            addPlayerTwo.SetActive(true);
            removePlayerTwo.SetActive(false);
        }

        //Player 3
        if (playerThreeReal == true)
        {
            charSlotThree.color = playerThreeColour;
            player3Text.text = player3Name;
            addPlayerThree.SetActive(false);
            removePlayerThree.SetActive(true);
        }

        else
        {
            charSlotThree.color = CPUColour;
            player3Text.text = CPU3Name;
            addPlayerThree.SetActive(true);
            removePlayerThree.SetActive(false);
        }

        //Player 4
        if (playerFourReal == true)
        {
            charSlotFour.color = playerFourColour;
            player4Text.text = player4Name;
            addPlayerFour.SetActive(false);
            removePlayerFour.SetActive(true);
        }

        else
        {
            charSlotFour.color = CPUColour;
            player4Text.text = CPU4Name;
            addPlayerFour.SetActive(true);
            removePlayerFour.SetActive(false);
        }
    }

    public void NextScene(string SceneName)
    {
        PlayerPrefs.SetString("Player 1 Username", player1Text.text);
        PlayerPrefs.SetString("Player 2 Username", player2Text.text);
        PlayerPrefs.SetString("Player 3 Username", player3Text.text);
        PlayerPrefs.SetString("Player 4 Username", player4Text.text);
        Debug.Log(PlayerPrefs.GetString("Player 1 Username"));
        Debug.Log(PlayerPrefs.GetString("Player 2 Username"));
        Debug.Log(PlayerPrefs.GetString("Player 3 Username"));
        Debug.Log(PlayerPrefs.GetString("Player 4 Username"));
        SceneManager.LoadScene(SceneName);
    }

    public void AddPlayer(int playerNumber)
    {
        
        if (playerNumber == 1)
        {
            if(PlayerPrefs.GetString("Player 1 Username") == "")
            {
                player1Name = "Player 1";
            }

            else
            {
                player1Name = PlayerPrefs.GetString("Player 1 Username");
            }

            player1Text.interactable = true;
            addPlayerOne.SetActive(false);
            removePlayerOne.SetActive(true);
            playerOneReal = true;
        }

        if (playerNumber == 2)
        {
            if (PlayerPrefs.GetString("Player 2 Username") == "")
            {
                player2Name = "Player 2";
            }

            else
            {
                player2Name = PlayerPrefs.GetString("Player 2 Username");
            }
            player2Text.interactable = true;
            addPlayerTwo.SetActive(false);
            removePlayerTwo.SetActive(true);
            playerTwoReal = true;
        }

        if (playerNumber == 3)
        {
            if (PlayerPrefs.GetString("Player 3 Username") == "")
            {
                player3Name = "Player 3";
            }

            else
            {
                player3Name = PlayerPrefs.GetString("Player 3 Username");
            }
            player3Text.interactable = true;
            addPlayerThree.SetActive(false);
            removePlayerThree.SetActive(true);
            playerThreeReal = true;
        }

        if (playerNumber == 4)
        {
            if (PlayerPrefs.GetString("Player 4 Username") == "")
            {
                player4Name = "Player 4";
            }

            else
            {
                player4Name = PlayerPrefs.GetString("Player 4 Username");
            }
            player4Text.interactable = true;
            addPlayerFour.SetActive(false);
            removePlayerFour.SetActive(true);
            playerFourReal = true;
        }
        BoolCheck();
    }

    public void RemovePlayer(int playerNumber)
    {
        
        if (playerNumber == 1)
        {
            PlayerPrefs.SetString("Player 1 Username", player1Text.text);
            addPlayerOne.SetActive(true);
            removePlayerOne.SetActive(false);
            playerOneReal = false;
            player1Text.interactable = false;
        }

        if (playerNumber == 2)
        {
            PlayerPrefs.SetString("Player 2 Username", player2Text.text);
            addPlayerTwo.SetActive(true);
            removePlayerTwo.SetActive(false);
            playerTwoReal = false;
            player2Text.interactable = false;
        }

        if (playerNumber == 3)
        {
            PlayerPrefs.SetString("Player 3 Username", player3Text.text);
            addPlayerThree.SetActive(true);
            removePlayerThree.SetActive(false);
            playerThreeReal = false;
            player3Text.interactable = false;
        }

        if (playerNumber == 4)
        {
            PlayerPrefs.SetString("Player 4 Username", player4Text.text);
            addPlayerFour.SetActive(true);
            removePlayerFour.SetActive(false);
            playerFourReal = false;
            player4Text.interactable = false;
        }
        BoolCheck();
    }
}
