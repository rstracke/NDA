using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, player.transform.position) < 1.2f)
        {
             UIController.Singleton.ShowInteractionTip(true);
             if (Input.GetKeyDown(KeyCode.E))
                UIController.Singleton.ShowInteractionWheel(true);
             else if (Input.GetKeyUp(KeyCode.E))
                UIController.Singleton.ShowInteractionWheel(false);
  
        }
        else
        {
            UIController.Singleton.ShowInteractionTip(false);
        }
    }

    private void OnDestroy()
    {
        UIController.Singleton.ShowInteractionTip(false);
    }
}
