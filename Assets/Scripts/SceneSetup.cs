using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetup : MonoBehaviour
{
    public int ID = 1;
    //SCENE NUMBER IS DETERMINED BY SCENE HIERARCHY
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(ID,LoadSceneMode.Single);
    }
}
