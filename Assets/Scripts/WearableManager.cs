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

    Animator anim;

    public ParticleSystem gateParticle;
    public ParticleSystem hatParticle;
    public ParticleSystem chestParticle;
    public ParticleSystem lowerParticle;
    public ParticleSystem bootParticle;

 

    public SwerveMovement swerveMovement;
   
    

   
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

    private void Update()
    {
      
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
               
               
                gateCache.gateEffect.SetActive(false);



                if (gateCache.type == Gate.GateType.Hats)
                {
                    hatParticle.Play();
                    SwitchHat(gateCache.returnHatTag());
                    barContoller.UITextDetection(gateCache.returnHatTag());
                    
                }


                if (gateCache.type == Gate.GateType.UpperBody)
                {
                    chestParticle.Play();
                    SwitchUpper(gateCache.returnUpperTag());
                    barContoller.UITextDetection(gateCache.returnUpperTag());
                }

                if (gateCache.type == Gate.GateType.LowerBody)
                {
                    lowerParticle.Play();
                    SwitchLower(gateCache.returnLowerTag());
                    barContoller.UITextDetection(gateCache.returnLowerTag());

                }

                if (gateCache.type == Gate.GateType.Boots)
                {
                    bootParticle.Play();
                    SwitchBoot(gateCache.returnBootTag());
                    barContoller.UITextDetection(gateCache.returnBootTag());
                }
               
            }
            barContoller.UpdateProgressFill(barContoller.CalculateValue(ReturnActiveHat(), ReturnActiveUpper(), ReturnActiveLower(), ReturnActiveBoot()));
            print(barContoller.CalculateValue(ReturnActiveHat(), ReturnActiveUpper(), ReturnActiveLower(), ReturnActiveBoot()));


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

           /* if (ReturnActiveHat() != null)
            {
                if (ReturnActiveHat() == "RomenHat")
                {
                    SwitchHat("BaseHat");
                    barContoller.UITextDetection("BaseHat");
                    barContoller.UpdateProgressFill(5);

                }
                if (ReturnActiveHat() == "EnglandHat")
                {
                    SwitchHat("RomenHat");
                    barContoller.UITextDetection("RomenHat");

                }
                if (ReturnActiveHat() == "CowboyHat")
                {
                    SwitchHat("EnglandHat");
                    barContoller.UITextDetection("EnglandHat");

                }
                if (ReturnActiveHat() == "DiscoHat")
                {
                    SwitchHat("CowboyHat");
                    barContoller.UITextDetection("CowboyHat");

                }
                if (ReturnActiveHat() == "SuitSunglass")
                {
                    SwitchHat("DiscoHat");
                    barContoller.UITextDetection("DiscoHat");

                }
            }

            if(ReturnActiveHat() =="BaseHat")
            {
                if (ReturnActiveUpper() == "RomenShirt")
                {
                    UpperBody[0].SetActive(false);
                    barContoller.UITextDetection("BaseHat");
                }
                if (ReturnActiveUpper() == "EnglandShirt")
                {
                    SwitchUpper("RomenShirt");
                    barContoller.UITextDetection("RomenShirt");
                }
                if (ReturnActiveUpper() == "CowboyShirt")
                {
                    SwitchUpper("EnglandShirt");
                    barContoller.UITextDetection("EnglandShirt");
                }
                if (ReturnActiveUpper() == "DiscoShirt")
                {
                    SwitchUpper("CowboyShirt");
                    barContoller.UITextDetection("CowboyShirt");
                }
                if (ReturnActiveUpper() == "SuitShirt")
                {
                    SwitchUpper("DiscoShirt");
                    barContoller.UITextDetection("DiscoShirt");
                }


            }
            if(ReturnActiveHat()=="BaseHat" && ReturnActiveUpper() == null)
            {
                if (ReturnActiveLower() == "RomenPants")
                {
                    SwitchLower("BasePants");
                    barContoller.UITextDetection("BasePants");
                }
                if (ReturnActiveLower() == "EnglandPant")
                {
                    SwitchLower("RomenPants");
                    barContoller.UITextDetection("RomenPants");
                }
                if (ReturnActiveLower() == "CowboyPants")
                {
                    SwitchLower("EnglandPant");
                    barContoller.UITextDetection("EnglandPant");
                }
                if (ReturnActiveLower() == "DiscoPants")
                {
                    SwitchLower("CowboyPants");
                    barContoller.UITextDetection("CowboyPants");
                }
                if (ReturnActiveLower() == "SuitPant")
                {
                    SwitchLower("DiscoPants");
                    barContoller.UITextDetection("DiscoPants");
                }
            }
            if(ReturnActiveUpper()==null && ReturnActiveLower() =="BasePants" && ReturnActiveHat() =="BaseHat")
            {
                
                if (ReturnActiveBoot() == "RomenShoe")
                {
                    Boots[0].SetActive(false);
                    barContoller.UITextDetection("BaseHat");
                }
                if (ReturnActiveBoot() == "EnglandShoe")
                {
                    SwitchBoot("RomenShoe");
                    barContoller.UITextDetection("RomenShoe");
                }
                if (ReturnActiveBoot() == "CowboyShoe")
                {
                    SwitchBoot("EnglandShoe");
                    barContoller.UITextDetection("EnglandShoe");
                }
                if (ReturnActiveBoot() == "DiscoShoe")
                {
                    SwitchBoot("CowboyShoe");
                    barContoller.UITextDetection("CowboyShoe");
                }
                if (ReturnActiveBoot() == "SuitShoe")
                {
                    SwitchBoot("DiscoShoe");
                    barContoller.UITextDetection("DiscoShoe");
                }

            }
            print(-1 * endscreen.CalculateScores(ReturnActiveHat(), ReturnActiveUpper(), ReturnActiveLower(), ReturnActiveBoot()));
            barContoller.UpdateProgressFill(-1*endscreen.CalculateScores(ReturnActiveHat(), ReturnActiveUpper(), ReturnActiveLower(), ReturnActiveBoot()));
           */
        }
    }


}
