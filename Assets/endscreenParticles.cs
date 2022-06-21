using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endscreenParticles : MonoBehaviour
{
    public ParticleSystem confetiParticle;
    public ParticleSystem firework1;
    public ParticleSystem firework2;

    // Start is called before the first frame update
    void Start()
    {
        confetiParticle.Play();
        firework1.Play();
        firework2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
