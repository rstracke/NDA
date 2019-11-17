using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject InteractionTip;
    public GameObject InteractionWheel;
    public static UIController Singleton {get; set;}
    
    // Start is called before the first frame update
    void Start()
    {
        if (Singleton == null)
        { 
            Singleton = this;
        } 
        else if(Singleton == this)
        { 
            Destroy(gameObject);
        }
        PlayerController.Singleton.OnPlayerNearInteractable_Action += ShowInteractionTip;
        PlayerController.Singleton.OnPlayerInterraction_Action += ShowInteractionWheel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowInteractionTip(bool state)
    {
        if (InteractionTip != null)
        {
            InteractionTip.SetActive(state);
        }
    }
    
    public void ShowInteractionWheel(bool state)
    {
        ShowInteractionTip(false);
        if (InteractionWheel != null)
        {
                    InteractionWheel.SetActive(state);
         }    
    }
}
