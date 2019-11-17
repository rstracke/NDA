using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Singleton {get; set;}
    
    public Action<GameObject, bool> OnPlayerInterraction_Action;
    public Action<GameObject, bool> OnPlayerNearInteractable_Action;

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
        
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
