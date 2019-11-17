using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractObject : MonoBehaviour
{
    public GameObject parentObject;

    private Rigidbody2D _Rigidbody2D;

    private void OnEnable()
    {
        InteractionController.Singleton.OnMagnet_Action += OnAtrraction;
        _Rigidbody2D = parentObject.GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        InteractionController.Singleton.OnMagnet_Action -= OnAtrraction;
    }

    // Start is called before the first frame update
    void Start()
    {
        InteractionController.Singleton.OnMagnet_Action += OnAtrraction;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAtrraction(GameObject go)
    {
        Debug.Log("OnMagnet");
        _Rigidbody2D.AddForce(20 * (transform.position - go.transform.position));
        if (Vector2.Distance(transform.position, go.transform.position) < 0.1f)
        {
            _Rigidbody2D.simulated = false;
            transform.SetParent(go.transform);
        }
    }
}
