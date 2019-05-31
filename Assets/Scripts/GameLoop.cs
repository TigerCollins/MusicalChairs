using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public bool initialised;

    public int playerCount;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialise()
    {
        maxChairs = GameObject.FindGameObjectsWithTag("Player").Length;
        maxChairCount = GameObject.FindGameObjectsWithTag("SpawnPoint").Length;
        canCountdown = true;
    }
    // Update is called once per frame
    void Update()
    {
        DiageticMusic();
        chairCount = GameObject.FindGameObjectsWithTag("Chair").Length;
        if (chairCount == 0)
        {
            canCountdown = true;
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

   
}

