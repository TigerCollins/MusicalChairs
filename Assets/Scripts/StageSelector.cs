using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageSelector : MonoBehaviour,ISelectHandler
{
    public int ID;
    public string levelName;
    public bool locked;
    private StagePreview stagePreview;
    private SceneSetup sceneSetup;

    public void Awake()
    {
        stagePreview = GameObject.Find("ScriptController").GetComponent<StagePreview>();
        sceneSetup = GameObject.Find("ScriptController").GetComponent<SceneSetup>();
    }

    public void Start()
    {
        Selecting();
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Selected- ID:" + ID + " | Level Name:" + levelName + " | Locked:" + locked);
        stagePreview.ID = ID;
        //sceneSetup.ID = ID;
        stagePreview.levelName = levelName;
        stagePreview.locked = locked;
        stagePreview.UpdatePreviewImage();
    }

    public void Selecting()
    {
        Debug.Log("Selected- ID:" + ID + " | Level Name:" + levelName + " | Locked:" + locked);
        stagePreview.ID = ID;
        //sceneSetup.ID = ID;
        stagePreview.levelName = levelName;
        stagePreview.locked = locked;
        stagePreview.UpdatePreviewImage();
    }

    public void Hovering()
    {
        stagePreview.ID = ID;
        stagePreview.levelName = levelName;
        stagePreview.locked = locked;
        stagePreview.UpdatePreviewImage();
    }

    public void OnChange()
    {
        sceneSetup.ID = ID;
    }
}
