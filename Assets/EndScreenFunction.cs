using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenFunction : MonoBehaviour
{
    public Animator firstJuriAnim;
    public Animator secondJuriAnim;
    public Animator thirdJuriAnim;
   


    public ParticleSystem confetiParticle;
    public ParticleSystem firework1;
    public ParticleSystem firework2;

    private void Start()
    {
        firstJuriAnim.enabled = false;
        secondJuriAnim.enabled = false;
        thirdJuriAnim.enabled = false;
        
    }

    public void EndFunction()
    {
        firstJuriAnim.enabled = true;
        secondJuriAnim.enabled = true;
        thirdJuriAnim.enabled = true;
        

        confetiParticle.Play();
        firework1.Play();
        firework2.Play();
    }
}
