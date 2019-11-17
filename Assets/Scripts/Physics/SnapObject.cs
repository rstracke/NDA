using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class SnapObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Magnetable")
        {
            other.transform.parent.GetComponent<Rigidbody2D>().simulated = false;
            if (other.transform.parent.tag == "Player")
            {
                other.transform.parent.transform.GetComponent<PlatformerCharacter2D>().enabled = false;
                other.transform.parent.transform.GetComponent<Platformer2DUserControl>().enabled = false;
                other.transform.parent.transform.GetComponent<Animator>().enabled = false;
            }
            other.transform.parent.transform.SetParent(transform);
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
