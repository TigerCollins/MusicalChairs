using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecifics : MonoBehaviour
{
    public string playerName;
    public Color playerColor;

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
