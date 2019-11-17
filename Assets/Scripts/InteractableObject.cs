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
        if (Vector2.Distance(transform.position, player.transform.position) < 1.0f)
        {
            PlayerController.Singleton.OnPlayerNearInteractable_Action?.Invoke(transform.GetChild(0).gameObject, true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerController.Singleton.OnPlayerInterraction_Action?.Invoke(transform.GetChild(0).gameObject, true);
                Debug.Log("[" + gameObject.name + " " +  Vector2.Distance(transform.position, player.transform.position) + "]");
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                PlayerController.Singleton.OnPlayerInterraction_Action?.Invoke(transform.GetChild(0).gameObject, false);
            }

        }
        else
        {
            PlayerController.Singleton.OnPlayerNearInteractable_Action?.Invoke(transform.GetChild(0).gameObject, false);
            uiShown = false;
        }
    }

    private void OnDestroy()
    {
        PlayerController.Singleton.OnPlayerNearInteractable_Action?.Invoke(transform.GetChild(0).gameObject, false);
        uiShown = false;
    }
}
