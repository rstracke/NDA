using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public ParticleSystem hitParticles;
    public bool hit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Hitting")
        {
            hitParticles.Emit(20);
        }

        throw new System.NotImplementedException();
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
            hitParticles.Emit(20);
            hit = false;
        }
    }
}
