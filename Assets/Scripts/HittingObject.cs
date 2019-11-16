using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingObject : MonoBehaviour
{
    public float hitDamage;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Damagable")
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
