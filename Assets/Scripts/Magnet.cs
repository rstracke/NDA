using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Magnet : MonoBehaviour
{
    public bool isObjectInField;
    public GameObject magnetableObject;
    public GameObject objectMagnetPoint;
    public GameObject myMagnetPoint;
    private Rigidbody2D _Rigidbody2D;
    public float initialForce = 100;
    

    public bool isHold;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Magnetable")
        {
            objectMagnetPoint = other.transform.gameObject;
            magnetableObject = other.transform.parent.gameObject;
            _Rigidbody2D = magnetableObject.GetComponent<Rigidbody2D>();
            /*Debug.Log(InteractionController.Singleton);
            InteractionController.Singleton.OnMagnet_Action?.Invoke(transform.gameObject);*/
            isObjectInField = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Magnetable")
        {
            magnetableObject = null;
            isObjectInField = false;
        }
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        objectMagnetPoint = null;
        magnetableObject = null;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHold && magnetableObject && objectMagnetPoint)
        {
            float dist = Vector2.Distance(myMagnetPoint.transform.position, objectMagnetPoint.transform.position);
            if (isObjectInField)
            {
                _Rigidbody2D.AddForce(initialForce/(dist* dist)  * (myMagnetPoint.transform.position - objectMagnetPoint.transform.position));
            }
            if (Vector2.Distance(myMagnetPoint.transform.position, objectMagnetPoint.transform.position) < 0.1f)
            {
                _Rigidbody2D.simulated = false;
                if (magnetableObject.tag == "Player")
                {
                    magnetableObject.GetComponent<PlatformerCharacter2D>().enabled = false;
                    magnetableObject.GetComponent<Platformer2DUserControl>().enabled = false;
                }
                magnetableObject.transform.SetParent(transform);
                isHold = true;
            }
        }
    }
}
