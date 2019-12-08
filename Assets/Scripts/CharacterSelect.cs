using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public HeroStats heroStatsScript;
    public string[] heroName;

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
    public Text heroName1;
    public InputField player1Text;
    public int p1HeroID;
    public Image p1StrengthSlider;
    public Image p1AgilitySlider;
    public Image p1DefenceSlider;

    [Header("Player 2 Variables")]
    public string player2Name;
    public Text heroName2;
    public InputField player2Text;
    public int p2HeroID;
    public Image p2StrengthSlider;
    public Image p2AgilitySlider;
    public Image p2DefenceSlider;

    [Header("Player 3 Variables")]
    public string player3Name;
    public Text heroName3;
    public InputField player3Text;
    public int p3HeroID;
    public Image p3StrengthSlider;
    public Image p3AgilitySlider;
    public Image p3DefenceSlider;

    [Header("Player 4 Variables")]
    public string player4Name;
    public Text heroName4;
    public InputField player4Text;
    public int p4HeroID;
    public Image p4StrengthSlider;
    public Image p4AgilitySlider;
    public Image p4DefenceSlider;

    [Header("CPU Variables")]
    public string CPU1Name;
    public string CPU2Name;
    public string CPU3Name;
    public string CPU4Name;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("Player 1 Username"));
        UsernamePull();
        BoolCheck();
        UpdatePlayer1Stat(0);
        UpdatePlayer2Stat(0);
        UpdatePlayer3Stat(0);
        UpdatePlayer4Stat(0);
    }


    void UsernamePull()
    {
        if (PlayerPrefs.GetString("Player 1 Username") != "")
        {
            player1Name = PlayerPrefs.GetString("Player 1 Username");

        }

        else
        {
            player1Name = "Player 1";
        }

        if (PlayerPrefs.GetString("Player 2 Username") != "")
        {
            player2Name = PlayerPrefs.GetString("Player 2 Username");

        }

        else
        {
            player2Name = "Player 2";
        }

        if (PlayerPrefs.GetString("Player 3 Username") != "")
        {
            player3Name = PlayerPrefs.GetString("Player 3 Username");

        }

        else
        {
            player3Name = "Player 3";
        }

        if (PlayerPrefs.GetString("Player 4 Username") != "")
        {
            player4Name = PlayerPrefs.GetString("Player 4 Username");

        }

        else
        {
            player4Name = "Player 4";
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayer1Stat(int heroID)
    {
        if (heroID == 0)
        {
            p1StrengthSlider.fillAmount = 0;
            p1AgilitySlider.fillAmount = 0;
            p1DefenceSlider.fillAmount = 0;
            p1HeroID = 0;
            heroName1.text = heroName[0];
        }

        if (heroID == 1)
        {
            p1StrengthSlider.fillAmount = heroStatsScript.h1StrengthStat / 100f;
            print(heroStatsScript.h1StrengthStat/100);
            p1AgilitySlider.fillAmount = heroStatsScript.h1AgilityStat / 100f;
            p1DefenceSlider.fillAmount = heroStatsScript.h1DefenceStat / 100f;
            p1HeroID = 1;
            heroName1.text = heroName[1];
        }

        if (heroID == 2)
        {
            p1StrengthSlider.fillAmount = heroStatsScript.h2StrengthStat / 100f;
            p1AgilitySlider.fillAmount = heroStatsScript.h2AgilityStat / 100f;
            p1DefenceSlider.fillAmount = heroStatsScript.h2DefenceStat / 100f;
            p1HeroID = 2;
            heroName1.text = heroName[2];
        }

        if (heroID == 3)
        {
            p1StrengthSlider.fillAmount = heroStatsScript.h3StrengthStat / 100;
            p1AgilitySlider.fillAmount = heroStatsScript.h3AgilityStat / 100;
            p1DefenceSlider.fillAmount = heroStatsScript.h3DefenceStat / 100;
            p1HeroID = 3;
            heroName1.text = heroName[3];
        }

        if (heroID == 4)
        {
            p1StrengthSlider.fillAmount = heroStatsScript.h4StrengthStat / 100;
            p1AgilitySlider.fillAmount = heroStatsScript.h4AgilityStat / 100;
            p1DefenceSlider.fillAmount = heroStatsScript.h4DefenceStat / 100;
            p1HeroID = 4;
            heroName1.text = heroName[4];
        }
    }

    public void UpdatePlayer2Stat(int heroID)
    {
        if (heroID == 0)
        {
            p2StrengthSlider.fillAmount = 0;
            p2AgilitySlider.fillAmount = 0;
            p2DefenceSlider.fillAmount = 0;
            p2HeroID = 0;
            heroName2.text = heroName[0];
        }

        if (heroID == 1)
        {
            p2StrengthSlider.fillAmount = heroStatsScript.h1StrengthStat / 100f;
            print(heroStatsScript.h1StrengthStat / 100);
            p2AgilitySlider.fillAmount = heroStatsScript.h1AgilityStat / 100f;
            p2DefenceSlider.fillAmount = heroStatsScript.h1DefenceStat / 100f;
            p2HeroID = 1;
            heroName2.text = heroName[1];
        }

        if (heroID == 2)
        {
            p2StrengthSlider.fillAmount = heroStatsScript.h2StrengthStat / 100f;
            p2AgilitySlider.fillAmount = heroStatsScript.h2AgilityStat / 100f;
            p2DefenceSlider.fillAmount = heroStatsScript.h2DefenceStat / 100f;
            p2HeroID = 2;
            heroName2.text = heroName[2];
        }

        if (heroID == 3)
        {
            p2StrengthSlider.fillAmount = heroStatsScript.h3StrengthStat / 100;
            p2AgilitySlider.fillAmount = heroStatsScript.h3AgilityStat / 100;
            p2DefenceSlider.fillAmount = heroStatsScript.h3DefenceStat / 100;
            p2HeroID = 3;
            heroName2.text = heroName[3];
        }

        if (heroID == 4)
        {
            p2StrengthSlider.fillAmount = heroStatsScript.h4StrengthStat / 100;
            p2AgilitySlider.fillAmount = heroStatsScript.h4AgilityStat / 100;
            p2DefenceSlider.fillAmount = heroStatsScript.h4DefenceStat / 100;
            p2HeroID = 4;
            heroName2.text = heroName[4];
        }
    }

    public void UpdatePlayer3Stat(int heroID)
    {
        if (heroID == 0)
        {
            p3StrengthSlider.fillAmount = 0;
            p3AgilitySlider.fillAmount = 0;
            p3DefenceSlider.fillAmount = 0;
            p3HeroID = 0;
            heroName3.text = heroName[0];
        }

        if (heroID == 1)
        {
            p3StrengthSlider.fillAmount = heroStatsScript.h1StrengthStat / 100f;
            print(heroStatsScript.h1StrengthStat / 100);
            p3AgilitySlider.fillAmount = heroStatsScript.h1AgilityStat / 100f;
            p3DefenceSlider.fillAmount = heroStatsScript.h1DefenceStat / 100f;
            p3HeroID = 1;
            heroName3.text = heroName[1];
        }

        if (heroID == 2)
        {
            p3StrengthSlider.fillAmount = heroStatsScript.h2StrengthStat / 100f;
            p3AgilitySlider.fillAmount = heroStatsScript.h2AgilityStat / 100f;
            p3DefenceSlider.fillAmount = heroStatsScript.h2DefenceStat / 100f;
            p3HeroID = 2;
            heroName3.text = heroName[2];
        }

        if (heroID == 3)
        {
            p3StrengthSlider.fillAmount = heroStatsScript.h3StrengthStat / 100;
            p3AgilitySlider.fillAmount = heroStatsScript.h3AgilityStat / 100;
            p3DefenceSlider.fillAmount = heroStatsScript.h3DefenceStat / 100;
            p3HeroID = 3;
            heroName3.text = heroName[3];
        }

        if (heroID == 4)
        {
            p3StrengthSlider.fillAmount = heroStatsScript.h4StrengthStat / 100;
            p3AgilitySlider.fillAmount = heroStatsScript.h4AgilityStat / 100;
            p3DefenceSlider.fillAmount = heroStatsScript.h4DefenceStat / 100;
            p3HeroID = 4;
            heroName3.text = heroName[4];
        }
    }

    public void UpdatePlayer4Stat(int heroID)
    {
        if (heroID == 0)
        {
            p4StrengthSlider.fillAmount = 0;
            p4AgilitySlider.fillAmount = 0;
            p4DefenceSlider.fillAmount = 0;
            p4HeroID = 0;
            heroName4.text = heroName[0];
        }

        if (heroID == 1)
        {
            p4StrengthSlider.fillAmount = heroStatsScript.h1StrengthStat / 100f;
            print(heroStatsScript.h1StrengthStat / 100);
            p4AgilitySlider.fillAmount = heroStatsScript.h1AgilityStat / 100f;
            p4DefenceSlider.fillAmount = heroStatsScript.h1DefenceStat / 100f;
            p4HeroID = 1;
            heroName4.text = heroName[1];
        }

        if (heroID == 2)
        {
            p4StrengthSlider.fillAmount = heroStatsScript.h2StrengthStat / 100f;
            p4AgilitySlider.fillAmount = heroStatsScript.h2AgilityStat / 100f;
            p4DefenceSlider.fillAmount = heroStatsScript.h2DefenceStat / 100f;
            p4HeroID = 2;
            heroName4.text = heroName[2];
        }

        if (heroID == 3)
        {
            p4StrengthSlider.fillAmount = heroStatsScript.h3StrengthStat / 100;
            p4AgilitySlider.fillAmount = heroStatsScript.h3AgilityStat / 100;
            p4DefenceSlider.fillAmount = heroStatsScript.h3DefenceStat / 100;
            p4HeroID = 3;
            heroName4.text = heroName[3];
        }

        if (heroID == 4)
        {
            p4StrengthSlider.fillAmount = heroStatsScript.h4StrengthStat / 100;
            p4AgilitySlider.fillAmount = heroStatsScript.h4AgilityStat / 100;
            p4DefenceSlider.fillAmount = heroStatsScript.h4DefenceStat / 100;
            p4HeroID = 4;
            heroName4.text = heroName[4];
        }
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
        if(p1HeroID == 0 || p1HeroID == 0 || p2HeroID == 0 || p3HeroID == 0 || p4HeroID == 0)
        {
            PlayerPrefs.SetString("Player 1 Username", player1Text.text);
            PlayerPrefs.SetString("Player 2 Username", player2Text.text);
            PlayerPrefs.SetString("Player 3 Username", player3Text.text);
            PlayerPrefs.SetString("Player 4 Username", player4Text.text);
            PlayerPrefs.SetFloat("Player 1 Strength", (p1StrengthSlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 1 Agility", (p1AgilitySlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 1 Defence", (p1DefenceSlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 2 Strength", (p2StrengthSlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 2 Agility", (p2AgilitySlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 2 Defence", (p2DefenceSlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 3 Strength", (p3StrengthSlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 3 Agility", (p3AgilitySlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 3 Defence", (p3DefenceSlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 4 Strength", (p4StrengthSlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 4 Agility", (p4AgilitySlider.fillAmount * 100));
            PlayerPrefs.SetFloat("Player 4 Defence", (p4DefenceSlider.fillAmount * 100));
        }

        if (PlayerPrefs.GetFloat("Player 1 Strength") == 0)
        {
            int randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                PlayerPrefs.SetFloat("Player 1 Strength", heroStatsScript.h1StrengthStat);
                PlayerPrefs.SetFloat("Player 1 Agility", heroStatsScript.h1AgilityStat);
                PlayerPrefs.SetFloat("Player 1 Defence", heroStatsScript.h1DefenceStat);
            }

            if (randNum == 2)
            {
                PlayerPrefs.SetFloat("Player 1 Strength", heroStatsScript.h2StrengthStat);
                PlayerPrefs.SetFloat("Player 1 Agility", heroStatsScript.h2AgilityStat);
                PlayerPrefs.SetFloat("Player 1 Defence", heroStatsScript.h2DefenceStat);
            }

            if (randNum == 3)
            {
                PlayerPrefs.SetFloat("Player 1 Strength", heroStatsScript.h3StrengthStat);
                PlayerPrefs.SetFloat("Player 1 Agility", heroStatsScript.h3AgilityStat);
                PlayerPrefs.SetFloat("Player 1 Defence", heroStatsScript.h3DefenceStat);
            }

            if (randNum == 4)
            {
                PlayerPrefs.SetFloat("Player 1 Strength", heroStatsScript.h4StrengthStat);
                PlayerPrefs.SetFloat("Player 1 Agility", heroStatsScript.h4AgilityStat);
                PlayerPrefs.SetFloat("Player 1 Defence", heroStatsScript.h4DefenceStat);
            }
        }


        if (PlayerPrefs.GetFloat("Player 2 Strength") == 0)
        {
            int randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                PlayerPrefs.SetFloat("Player 2 Strength", heroStatsScript.h1StrengthStat);
                PlayerPrefs.SetFloat("Player 2 Agility", heroStatsScript.h1AgilityStat);
                PlayerPrefs.SetFloat("Player 2 Defence", heroStatsScript.h1DefenceStat);
            }

            if (randNum == 2)
            {
                PlayerPrefs.SetFloat("Player 2 Strength", heroStatsScript.h2StrengthStat);
                PlayerPrefs.SetFloat("Player 2 Agility", heroStatsScript.h2AgilityStat);
                PlayerPrefs.SetFloat("Player 2 Defence", heroStatsScript.h2DefenceStat);
            }

            if (randNum == 3)
            {
                PlayerPrefs.SetFloat("Player 2 Strength", heroStatsScript.h3StrengthStat);
                PlayerPrefs.SetFloat("Player 2 Agility", heroStatsScript.h3AgilityStat);
                PlayerPrefs.SetFloat("Player 2 Defence", heroStatsScript.h3DefenceStat);
            }

            if (randNum == 4)
            {
                PlayerPrefs.SetFloat("Player 2 Strength", heroStatsScript.h4StrengthStat);
                PlayerPrefs.SetFloat("Player 2 Agility", heroStatsScript.h4AgilityStat);
                PlayerPrefs.SetFloat("Player 2 Defence", heroStatsScript.h4DefenceStat);
            }
        }

        if (PlayerPrefs.GetFloat("Player 3 Strength") == 0)
        {
            int randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                PlayerPrefs.SetFloat("Player 3 Strength", heroStatsScript.h1StrengthStat);
                PlayerPrefs.SetFloat("Player 3 Agility", heroStatsScript.h1AgilityStat);
                PlayerPrefs.SetFloat("Player 3 Defence", heroStatsScript.h1DefenceStat);
            }

            if (randNum == 2)
            {
                PlayerPrefs.SetFloat("Player 3 Strength", heroStatsScript.h2StrengthStat);
                PlayerPrefs.SetFloat("Player 3 Agility", heroStatsScript.h2AgilityStat);
                PlayerPrefs.SetFloat("Player 3 Defence", heroStatsScript.h2DefenceStat);
            }

            if (randNum == 3)
            {
                PlayerPrefs.SetFloat("Player 3 Strength", heroStatsScript.h3StrengthStat);
                PlayerPrefs.SetFloat("Player 3 Agility", heroStatsScript.h3AgilityStat);
                PlayerPrefs.SetFloat("Player 3 Defence", heroStatsScript.h3DefenceStat);
            }

            if (randNum == 4)
            {
                PlayerPrefs.SetFloat("Player 3 Strength", heroStatsScript.h4StrengthStat);
                PlayerPrefs.SetFloat("Player 3 Agility", heroStatsScript.h4AgilityStat);
                PlayerPrefs.SetFloat("Player 3 Defence", heroStatsScript.h4DefenceStat);
            }
        }

        if (PlayerPrefs.GetFloat("Player 4 Strength") == 0)
        {
            int randNum = Random.Range(1, 4);
            if (randNum == 1)
            {
                PlayerPrefs.SetFloat("Player 4 Strength", heroStatsScript.h1StrengthStat);
                PlayerPrefs.SetFloat("Player 4 Agility", heroStatsScript.h1AgilityStat);
                PlayerPrefs.SetFloat("Player 4 Defence", heroStatsScript.h1DefenceStat);
            }

            if (randNum == 2)
            {
                PlayerPrefs.SetFloat("Player 4 Strength", heroStatsScript.h2StrengthStat);
                PlayerPrefs.SetFloat("Player 4 Agility", heroStatsScript.h2AgilityStat);
                PlayerPrefs.SetFloat("Player 4 Defence", heroStatsScript.h2DefenceStat);
            }

            if (randNum == 3)
            {
                PlayerPrefs.SetFloat("Player 4 Strength", heroStatsScript.h3StrengthStat);
                PlayerPrefs.SetFloat("Player 4 Agility", heroStatsScript.h3AgilityStat);
                PlayerPrefs.SetFloat("Player 4 Defence", heroStatsScript.h3DefenceStat);
            }

            if (randNum == 4)
            {
                PlayerPrefs.SetFloat("Player 4 Strength", heroStatsScript.h4StrengthStat);
                PlayerPrefs.SetFloat("Player 4 Agility", heroStatsScript.h4AgilityStat);
                PlayerPrefs.SetFloat("Player 4 Defence", heroStatsScript.h4DefenceStat);
            }
        }

        Debug.Log(PlayerPrefs.GetString("Player 1 Username"));
        Debug.Log(PlayerPrefs.GetString("Player 2 Username"));
        Debug.Log(PlayerPrefs.GetString("Player 3 Username"));
        Debug.Log(PlayerPrefs.GetString("Player 4 Username"));
        SceneManager.LoadScene(SceneName);
    }

    public void updatePlayerPrefString(int playerNumber)
    {
        if (playerNumber == 1)
        {
            PlayerPrefs.SetString("Player 1 Username", player1Text.text);
            player1Name = player1Text.text;
        }
        if (playerNumber == 2)
        {
            PlayerPrefs.SetString("Player 2 Username", player2Text.text);
            player2Name = player2Text.text;
        }
        if (playerNumber == 3)
        {
            PlayerPrefs.SetString("Player 3 Username", player3Text.text);
            player3Name = player3Text.text;
        }
        if (playerNumber == 4)
        {
            PlayerPrefs.SetString("Player 4 Username", player4Text.text);
            player4Name = player4Text.text;
        }
    }

    public void AddPlayer(int playerNumber)
    {
        
        if (playerNumber == 1)
        {
            if(PlayerPrefs.GetString("Player 1 Username") != "")
            {
                player1Name = PlayerPrefs.GetString("Player 1 Username");
               
            }

            else
            {
                player1Name = "Player 1";
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
