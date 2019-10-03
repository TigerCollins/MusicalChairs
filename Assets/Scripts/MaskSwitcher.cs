using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MaskSwitcher : MonoBehaviour, ISelectHandler
{
    public string currentlySelected;
    public Toggle thisToggle;
    public Image thisMask;
    public EventSystem eventSystem;
    public Image selectorIcon;

    [Header("Current State")]
    public bool hovering;
    public bool selected;
    public bool canDeselect;

    [Header("Mask Options")]
    //None is a option.
    public Sprite selectedStage;
    public Sprite hoveringStage;
    public Color noColour;
    public Color withColour;

    // Start is called before the first frame update
    void Start()
    {
        thisToggle = gameObject.GetComponent<Toggle>();
        thisMask = gameObject.GetComponent<Image>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();


        ValueChanged();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(this.gameObject.name + " was selected");
    }

    public void ValueChanged()
    {
        if (thisToggle.isOn == false)
        {
            selected = false;
            thisMask.sprite = null;
            selectorIcon.color = noColour;
        }

        if (thisToggle.isOn == true)
        {
            selected = true;
            thisMask.sprite = selectedStage;
            selectorIcon.color = withColour;
        }


    }

    public void Hover()
    {
        
        if(!selected)
        {
            thisMask.sprite = hoveringStage;
            hovering = true;
        }

        else
        {
            selected = true;
        }

    }

    public void Selected()
    {
        if (thisToggle.isOn == false)
        {
            thisMask.sprite = hoveringStage;
        }
        
    }

    public void Deselect()
    {
        if(selected)
        { 
            thisMask.sprite = null;
            selected = false;
            hovering = false;
        }

    }

    public void Exited()
    {
        if(!selected)
        {
            thisMask.sprite = null;
            hovering = false;
        }    
        
        
    }

   


}
