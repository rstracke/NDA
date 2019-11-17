using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class InteractableObject : MonoBehaviour
{
    public GameObject player;

    public bool uiShown;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformerCharacter2D>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, player.transform.position) < 1.2f)
        {
            if (!uiShown)
                PlayerController.Singleton.OnPlayerNearInteractable_Action?.Invoke(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerController.Singleton.OnPlayerInterraction_Action?.Invoke(true);
                uiShown = true;
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                PlayerController.Singleton.OnPlayerInterraction_Action?.Invoke(false);
            }

        }
        else
        {
            PlayerController.Singleton.OnPlayerNearInteractable_Action?.Invoke(false);
        }
    }

    private void OnDestroy()
    {
        PlayerController.Singleton.OnPlayerNearInteractable_Action?.Invoke(false);
    }
}
