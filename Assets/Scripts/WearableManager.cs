using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
public class WearableManager : MonoBehaviour
{
    private Gate gateCache;

    public GameObject[] Hats;
    public GameObject[] UpperBody;
    public GameObject[] LowerBody;
    public GameObject[] Boots;

   

    public BarContoller barContoller;

    public Animator anim;

    public ParticleSystem hatParticle;
    public ParticleSystem chestParticle;
    public ParticleSystem lowerParticle;
    public ParticleSystem bootParticle;

 

    public SwerveMovement swerveMovement;
   
    

   
    void Start()
    {
       
      
       

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

    private void Update()
    {
      
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            anim.SetTrigger("GatePassed");
           
            
           

            if(other.GetComponent<Gate>() != null)
            { 
                gateCache= other.GetComponent<Gate>();
               
               
                gateCache.gateEffect.SetActive(false);



                if (gateCache.type == Gate.GateType.Hats)
                {
                    hatParticle.Play();
                    SwitchHat(gateCache.returnHatTag());
                    
                    
                }


                if (gateCache.type == Gate.GateType.UpperBody)
                {
                    chestParticle.Play();
                    SwitchUpper(gateCache.returnUpperTag());
                   ;
                }

                if (gateCache.type == Gate.GateType.LowerBody)
                {
                    lowerParticle.Play();
                    SwitchLower(gateCache.returnLowerTag());
                    

                }

                if (gateCache.type == Gate.GateType.Boots)
                {
                    bootParticle.Play();
                    SwitchBoot(gateCache.returnBootTag());
                   
                }
               
            }
            barContoller.UpdateProgressFill(barContoller.CalculateValue(ReturnActiveHat(), ReturnActiveUpper(), ReturnActiveLower(), ReturnActiveBoot()));
         


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
    public string ReturnActiveHat()
    {
        foreach (var hats in Hats)
        {
            if (hats.activeInHierarchy)
            {
                return hats.tag;
            }
        }
        return null;
    }
    public string ReturnActiveUpper()
    {
        foreach (var upper in UpperBody)
        {
            if (upper.activeInHierarchy)
            {
                return upper.tag;
            }
        }
        return null;
    }
    public string ReturnActiveLower()
    {
        foreach (var lower in LowerBody)
        {
            if (lower.activeInHierarchy)
            {
                return lower.tag;
            }
        }
        return null;
    }
    public string ReturnActiveBoot()
    {
        foreach (var boot in Boots)
        {
            if (boot.activeInHierarchy)
            {
                return boot.tag;
            }
        }
        return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            swerveMovement.KnockBack();
            MMVibrationManager.Haptic(HapticTypes.Warning);

           
        }
    }


}
