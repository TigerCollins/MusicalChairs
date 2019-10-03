using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StagePreview : MonoBehaviour
{
    private StageSelector stageSelector;
    public Sprite[] sprites;
    public string[] stageNames;

    [Header("Stage Selection Scene")]
    public Image PreviewImage;
    public Text stageNameText;

    [Header("Selected Data")]
    public int ID = 1;
    public string levelName;
    public bool locked;
    // Start is called before the first frame update
    void Awake()
    {
        //stageSelector = GameObject.Find("ScriptController").GetComponent<StageSelector>();
        UpdatePreviewImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePreviewImage()
    {
        PreviewImage.sprite = sprites[ID - 1];
        stageNameText.text = stageNames[ID - 1];
    }

    public void RetrieveSelectorStats()
    {

    }

    public void HoveringUI()
    {
        PreviewImage.sprite = sprites[ID - 1];
        stageNameText.text = stageNames[ID - 1];
    }

}
