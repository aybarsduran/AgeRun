using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearableManager : MonoBehaviour
{
    private Gate gateCache;

    public GameObject[] Hats;
    public GameObject[] UpperBody;
    public GameObject[] LowerBody;
    public GameObject[] Boots;

    Animator anim;

    public ParticleSystem gateParticle;
    

   
    void Start()
    {
      
       anim=GetComponent<Animator>();

        foreach (var hats in Hats)
        {
            hats.gameObject.SetActive(false);
        }
        foreach (var upp in UpperBody)
        {
            upp.gameObject.SetActive(false);
        }
        foreach (var low in LowerBody)
        {
            low.gameObject.SetActive(false);
        }
        foreach (var boots in Boots)
        {
            boots.gameObject.SetActive(false);
        }

        Hats[0].SetActive(true);
        LowerBody[0].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            anim.SetTrigger("GatePassed");
            gateParticle.Play();
            if(other.GetComponent<Gate>() != null)
            { 
                gateCache= other.GetComponent<Gate>();
            
            
                if (gateCache.type == Gate.GateType.Hats)
                {
                
                    SwitchHat(gateCache.returnHatTag());
                }


                if (gateCache.type == Gate.GateType.UpperBody)
                {
                    SwitchUpper(gateCache.returnUpperTag());
                }

                if (gateCache.type == Gate.GateType.LowerBody)
                {
                    SwitchLower(gateCache.returnLowerTag());
                }

                if (gateCache.type == Gate.GateType.Boots)
                {
                    SwitchBoot(gateCache.returnBootTag());
                }

            }


        }
    }

    public void SwitchHat(string tag)
    {
        foreach (var hats in Hats)
        {
            if (hats.tag == tag)
            {
                hats.SetActive(true);

            }
            if (hats.tag != tag)
            {
                hats.SetActive(false);
            }
        }
    }

    public void SwitchUpper(string tag)
    {
        foreach(var uppers in UpperBody)
        {
            if (uppers.tag == tag)
            {
                uppers.SetActive(true);

            }
            if(uppers.tag != tag)
            {
                uppers.SetActive(false);
            }
        }
    }
    
    public void SwitchLower(string tag)
    {
        foreach (var lowers in LowerBody)
        {
            if (lowers.tag == tag)
            {
                lowers.SetActive(true);

            }
            if (lowers.tag != tag)
            {
                lowers.SetActive(false);
            }
        }
    }
    public void SwitchBoot(string tag)
    {
        foreach (var boots in Boots)
        {
            if (boots.tag == tag)
            {
                boots.SetActive(true);

            }
            if (boots.tag != tag)
            {
                boots.SetActive(false);
            }
        }
    }


}
