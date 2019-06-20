using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitizialiser : MonoBehaviour
{
    [Header("Script References")]
    private GameLoop gameLoop;
    public Text countdownText;
    public int countdownTimer = 5;
    

    IEnumerator CountdownDisplay()
    {
        if(countdownTimer>0)
        {
            countdownText.text = countdownTimer.ToString();
        }
       
        else
        {
            countdownText.text = "";
        }
        yield return new WaitForSeconds(1);
        Countdown();
        StartCoroutine(CountdownDisplay());
    }

    void Start()
    {
        gameLoop = GameObject.Find("Script Controller").GetComponent<GameLoop>();
        StartCoroutine(CountdownDisplay());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initializer()
    {
        gameLoop.Initialise();
    }

    public void Countdown()
    {

        if(countdownTimer > 0)
        {
            countdownTimer -= 1;
           

        }

        if (countdownText.text == "" && gameLoop.initialised == false)
        {
            Initializer();
            gameLoop.initialised = true;
        }
        
    }
}
