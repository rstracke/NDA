using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionController : MonoBehaviour
{
    public static InteractionController Singleton;

    public UnityAction<GameObject> OnMagnet_Action;

    public Action<GameObject> OnSwitchInteract_Action;

    private void Awake()
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

    private void OnEnable()
    {
        
    }

    private void OnDestroy()
    {
        OnMagnet_Action = null;
        OnSwitchInteract_Action = null;
    }
}
