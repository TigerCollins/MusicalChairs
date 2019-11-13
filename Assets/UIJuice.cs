using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIJuice : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Size Adjustment")]
    public Button thisButton;
    public Toggle thisToggle;
    public float expansionSize;
    public bool hasSeperateImage;
    public Image seperateImage;
    public Vector3 originalOtherButtonSize;
    public Vector3 originalSize;

    public bool selected;
    public bool hover;

    [Header("Image Adjustment")]
    public bool doesImageChange;
    public Sprite orignalImage;
    public Sprite newImage;

    // Start is called before the first frame update
    void Awake()
    {
        if(this.gameObject.GetComponent<Button>() != null)
        {
            thisButton = this.gameObject.GetComponent<Button>();
            originalSize = thisButton.transform.localScale;
        }

        if (this.gameObject.GetComponent<Toggle>() != null)
        {
            thisToggle = this.gameObject.GetComponent<Toggle>();
            originalSize = thisToggle.transform.localScale;
            orignalImage = thisToggle.GetComponent<Image>().sprite;
            if(doesImageChange == true)
            {
                ToggleIsOnOff();
            }
            


        }

       
        if (hasSeperateImage == true)
        {
            originalOtherButtonSize = seperateImage.transform.localScale;
        }
    }

    void Start()
    {
        if (this.gameObject.GetComponent<Toggle>() != null)
        {

            if (thisToggle.isOn == true)
            {
                thisToggle.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
                   // thisToggle.image.sprite = newImage;

            }

            else
            {
                thisToggle.transform.localScale = originalSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selected == false && hover == false)
        {
            if(thisButton !=null)
            {
                thisButton.transform.localScale = originalSize;
            }

            if (thisToggle != null && thisToggle.isOn == false )
            {
                thisToggle.transform.localScale = originalSize;
            }


            if (hasSeperateImage == true)
            {
                seperateImage.transform.localScale = originalOtherButtonSize;
            }
        }

        if(thisToggle != null && thisToggle.isOn == true)
        {
//
        }
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        selected = true;
        if (thisButton != null)
        {
            thisButton.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
        }

        if (thisToggle != null)
        {
            thisToggle.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
        }

        if (hasSeperateImage == true)
        {
            print("ahhh");
            seperateImage.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
        }
    }

    public void OnDeselect(BaseEventData data)
    {
        selected = false;
        hover = false;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        hover = true;
        if (thisButton != null)
        {
            thisButton.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
        }

        if (thisToggle != null)
        {
            thisToggle.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
        }

            if (hasSeperateImage == true)
        {
            print("ahhh");
            seperateImage.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (selected == false)
        {
            hover = false;
        }

    }

    public void ToggleIsOnOff()
    {
        if (thisToggle != null && doesImageChange == true)
        {
            if (thisToggle.isOn == true)
            {
                thisToggle.transform.localScale = new Vector3(expansionSize, expansionSize, expansionSize);
                thisToggle.image.sprite = newImage;
            }

            else
            {
                thisToggle.transform.localScale = originalSize;
                thisToggle.image.sprite = orignalImage;
            }
        }

      
    }

}

