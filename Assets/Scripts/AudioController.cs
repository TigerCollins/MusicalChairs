using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Script References")]
    public GameLoop gameLoopScript;

    [Header("Audio Source")]
    public AudioSource soundtrackAudioSource;

    [Header("Audio Clips")]
    public AudioClip soundtrackA;

    [Header("Debug Variables")]
    public int chairCount;
    // Start is called before the first frame update
    void Start()
    {
        soundtrackAudioSource.clip = soundtrackA;
        soundtrackAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        chairCount = gameLoopScript.chairCount;

        if(chairCount != 0)
        {  
            soundtrackAudioSource.Pause();
        }

        if (chairCount <= 0 && soundtrackAudioSource.isPlaying == false)
        {
            soundtrackAudioSource.Play();
        }

    }
}
