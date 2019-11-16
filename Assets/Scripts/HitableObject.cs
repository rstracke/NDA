using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitableObject : MonoBehaviour
{
    public float hitDamage;

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "damagable")
        {
            other.GetComponent<DamagableObject>().health -= hitDamage;
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
