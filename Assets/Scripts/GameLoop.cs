using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public bool initialised;

    public int playerCount;

    [Header("Purge Player Settings")]
    public GameObject[] playerObject;
    public bool beenPurged;

    [Header("Music Settings")]
    public bool canCountdown; // countdown to music stopping
    public bool soundtrackPlaying;
    public int minSoundtrackTime;
    public int maxSoundtrackTime;
    public float soundtrackTimer;

    [Header("Chair Options")]
    public List<int> chairList = new List<int>();
    private bool initialSpawnBool = true;
    private int maxChairCount;
    public int randomSpawn;
    public int maxChairs;
    public int chairCount;
    public GameObject chairObject;
    public GameObject[] chairSpawnPoints;


    [Header("Gameover Options")]
    private PlayerSpecifics playerSpecifics;
    public string playerString;
    public Text playerWin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialise()
    {
        maxChairs = GameObject.FindGameObjectsWithTag("Player").Length;
        maxChairCount = GameObject.FindGameObjectsWithTag("SpawnPoint").Length;
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        canCountdown = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(playerCount == 1)
        {
            GameOver();
        }

        DiageticMusic();
        chairCount = GameObject.FindGameObjectsWithTag("Chair").Length;
        if (chairCount == 0)
        {
            canCountdown = true;
            
        }

        if(chairCount == 0 && initialised == true && initialSpawnBool == false && playerCount > 1)
        {
            PlayerPurge();
        }
    }

    public void DiageticMusic()
    {
        if (canCountdown == true && initialised ==  true)
        {
            soundtrackTimer -= Time.deltaTime;
        }

        if (soundtrackTimer <= 0)
        {
            SetMusicTimer();
            SpawnChairs();
        }
    }

    public void SetMusicTimer()
    {
        soundtrackTimer = Random.Range(minSoundtrackTime, maxSoundtrackTime);
    }

    public void SpawnChairs()
    {
        beenPurged = false;

        //SpawnPoints
        for (int i = 0; i < maxChairCount; i++)
        {
            chairList.Add(i);
        }

        //Stops the countdown timer
        canCountdown = false;

        //Spawns chairs at different spawnpoints
        if (chairCount < maxChairs)//1
        {
            if (initialSpawnBool == true)
            {
                var boi0 = Instantiate(chairObject, chairSpawnPoints[GetNonRepeatRandom()].transform);
                chairCount = GameObject.FindGameObjectsWithTag("Chair").Length;
                initialSpawnBool = false;
            }

            if (chairCount < maxChairs)//2
            {
                var boi1 = Instantiate(chairObject, chairSpawnPoints[GetNonRepeatRandom()].transform);
                chairCount = GameObject.FindGameObjectsWithTag("Chair").Length;

                if (chairCount < maxChairs)//3
                {
                    var boi2 = Instantiate(chairObject, chairSpawnPoints[GetNonRepeatRandom()].transform);
                    chairCount = GameObject.FindGameObjectsWithTag("Chair").Length;

                    if (chairCount < maxChairs)//4
                    {
                        var boi3 = Instantiate(chairObject, chairSpawnPoints[GetNonRepeatRandom()].transform);
                        chairCount = GameObject.FindGameObjectsWithTag("Chair").Length;
                    }
                     
                }
            }
        }
        
        
    }

    public int GetNonRepeatRandom()
    {
        int value = chairList[randomSpawn];
        chairList.RemoveAt(randomSpawn);

        if (chairList.Count == 0)
        {
            return -1;
        }
        return value;
    }

    public void PlayerPurge()
    {
        if(beenPurged ==  false)
        {
            if (playerObject[0] != null)
            {
                if (playerObject[0].GetComponent<PlayerController>().inChair == false)
                {
                    playerObject[0].SetActive(false);
                    //playerObject[0].GetComponent<MeshRenderer>().enabled = false;
                    //playerObject[0].GetComponent<PlayerController>().enabled = false;
                }
            }

            if (playerObject[1] != null)
            {
                if (playerObject[1].GetComponent<PlayerController>().inChair == false)
                {
                    playerObject[1].SetActive(false);
                    //Destroy(playerObject[1]); // UPDATE?
                }
            }

            if (playerObject[2] != null)
            {
                if (playerObject[2].GetComponent<PlayerController>().inChair == false)
                {
                    playerObject[2].SetActive(false);
                    //Destroy(playerObject[2]); // UPDATE?
                }
            }

            if (playerObject[3] != null)
            {
                if (playerObject[3].GetComponent<PlayerController>().inChair == false)
                {
                    playerObject[3].SetActive(false);
                    //Destroy(playerObject[3]); // UPDATE?
                }
            }

            beenPurged = true;
        }

        if(beenPurged == true)
        {
            if (playerObject[0] != null)
            {
                playerObject[0].GetComponent<PlayerController>().inChair = false;
            }

            if (playerObject[1] != null)
            {
                playerObject[1].GetComponent<PlayerController>().inChair = false;
            }

            if (playerObject[2] != null)
            {
                playerObject[2].GetComponent<PlayerController>().inChair = false;
            }

            if (playerObject[3] != null)
            {
                playerObject[3].GetComponent<PlayerController>().inChair = false;
            }

            
        }

        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
    }

    public void GameOver()
    {
        playerSpecifics = GameObject.Find("Player").GetComponent<PlayerSpecifics>();
        playerString = playerSpecifics.playerName;
        playerWin.text = playerString + " is the winner!";

    }

}

