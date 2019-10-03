using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuSpecific : MonoBehaviour
{
    [Header("Pause Menu Variables")]
    public GameObject pauseMenuCanvas;
    public bool paused;

    [Header("Scene Header Variables")]
    public Text mapNameText;
    public string mapName;
    // Start is called before the first frame update
    void Awake()
    {
        mapName = SceneManager.GetActiveScene().name;
        mapNameText.text = mapName;

        pauseMenuCanvas = GameObject.Find("Pause Menu Prefab");
        pauseMenuCanvas.SetActive(false);

        if (pauseMenuCanvas.activeSelf == true)
        {
            Paused();
        }

        else
        {
            BasicResume();
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Pause menu hotkey
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Gamepad Pause"))
        {
            Paused();
        }
    }

    public void Paused()
    {
        paused = true;
        Time.timeScale = 0;
        pauseMenuCanvas.SetActive(true);
    }

    public void BasicResume()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenuCanvas.SetActive(false);
    }

    
}
