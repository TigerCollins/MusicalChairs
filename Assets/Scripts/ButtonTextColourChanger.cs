using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTextColourChanger : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool selected;
    public bool hover;
    public Button thisButton;
    public Color newColor;
    private Color baseColor;

    // Start is called before the first frame update
    void Awake()
    {
        thisButton = this.gameObject.GetComponent<Button>();
        baseColor = thisButton.transform.GetChild(0).gameObject.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == false && hover == false)
        {
            thisButton.transform.GetChild(0).gameObject.GetComponent<Text>().color = baseColor;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        selected = true;
        thisButton.transform.GetChild(0).gameObject.GetComponent<Text>().color = newColor;
    }

    public void OnDeselect(BaseEventData data)
    {
        selected = false;
        hover = false;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        hover = true;
        thisButton.transform.GetChild(0).gameObject.GetComponent<Text>().color = newColor;
    }

    public void OnPointerExit(PointerEventData data)
    {
        if(selected == false)
        {
            hover = false;
        }
        
    }

}
