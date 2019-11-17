using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public ParticleSystem hitParticles;
    public bool hit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hitting")
        {
            Debug.Log("Hitting");
            hitParticles.Emit(2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            hitParticles.Emit(2);
            hit = false;
        }
    }
}
