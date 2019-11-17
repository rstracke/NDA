using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject InteractionTip;
    public GameObject InteractionWheel;
    
    public Text InteractionTipText;
    public Image InteractionWheelImage;
    public static UIController Singleton {get; set;}

    private void OnEnable()
    {
        if (Singleton == null)
        { 
            Singleton = this;
        } 
        else if(Singleton == this)
        { 
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Singleton.OnPlayerNearInteractable_Action += ShowInteractionTip;
        PlayerController.Singleton.OnPlayerInterraction_Action += ShowInteractionWheel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowInteractionTip(GameObject go, bool state)
    {
        if (InteractionTip != null)
        {
            InteractionTip.SetActive(state);
            ClampUIText(go);
        }
    }
    
    public void ShowInteractionWheel(GameObject go, bool state)
    {
        ShowInteractionTip(go, false);
        if (InteractionWheel != null)
        {
            InteractionWheel.SetActive(state);
            ClampUIImage(go);
        }    
    }

    void ClampUIText(GameObject go)
    {
        if (InteractionTipText != null)
        {
            InteractionTipText.transform.position = Camera.main.WorldToScreenPoint(go.transform.position);
        }
    }
    
    void ClampUIImage(GameObject go)
    {
        if (InteractionWheelImage != null)
        {
            InteractionWheelImage.transform.position = Camera.main.WorldToScreenPoint(go.transform.position);
        }
    }
}
