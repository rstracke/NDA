using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;
    public Action OnPlayerClose_Action;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, player.transform.position) < 1.2f)
        {
            if (UI != null) 
                UI.SetActive(true);
        }
        else
        {
            if (UI != null) 
                UI.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (UI != null) 
            UI.SetActive(false);
    }
}
