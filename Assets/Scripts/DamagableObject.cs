using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{

    public float health = 100f;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "damagable")
        {
            health -= other.collider.GetComponent<HitableObject>().hitDamage;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
