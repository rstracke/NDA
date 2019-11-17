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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Magnetable")
        {
            objectMagnetPoint = other.transform.gameObject;
            magnetableObject = other.transform.parent.gameObject;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isObjectInField && magnetableObject)
        {
            if (magnetableObject.tag == "Player")
            {
                //magnetableObject.GetComponent<PlatformerCharacter2D>().enabled = false;
                //magnetableObject.GetComponent<Platformer2DUserControl>().enabled = false;

            }

            magnetableObject.GetComponent<Rigidbody2D>().isKinematic = true;
            magnetableObject.GetComponent<Rigidbody2D>().AddForce(10 * (myMagnetPoint.transform.position - objectMagnetPoint.transform.position));
        }
        if (Vector2.Distance(myMagnetPoint.transform.position, transform.position) < 0.1f)
            magnetableObject.transform.SetParent(transform);
    }
}
