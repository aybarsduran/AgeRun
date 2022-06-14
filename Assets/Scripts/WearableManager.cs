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

    public BarContoller barController;
    

   
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
            //barController.ChangeColor();

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
            if (ReturnActiveHat() != null)
            {
                if (ReturnActiveHat() == "RomenHat")
                {
                    SwitchHat("BaseHat");

                }
                if (ReturnActiveHat() == "EnglandHat")
                {
                    SwitchHat("RomenHat");

                }
                if (ReturnActiveHat() == "CowboyHat")
                {
                    SwitchHat("EnglandHat");

                }
                if (ReturnActiveHat() == "DiscoHat")
                {
                    SwitchHat("CowboyHat");

                }
                if (ReturnActiveHat() == "SuitSunglass")
                {
                    SwitchHat("DiscoHat");

                }
            }

            if(ReturnActiveHat() =="BaseHat")
            {
                if (ReturnActiveUpper() == "RomenShirt")
                {
                    UpperBody[0].SetActive(false);
                }
                if (ReturnActiveUpper() == "EnglandShirt")
                {
                    SwitchUpper("RomenShirt");
                }
                if (ReturnActiveUpper() == "CowboyShirt")
                {
                    SwitchUpper("EnglandShirt");
                }
                if (ReturnActiveUpper() == "DiscoShirt")
                {
                    SwitchUpper("CowboyShirt");
                }
                if (ReturnActiveUpper() == "SuitShirt")
                {
                    SwitchUpper("DiscoShirt");
                }


            }
            if(ReturnActiveHat()=="BaseHat" && ReturnActiveUpper() == null)
            {
                if (ReturnActiveLower() == "RomenPants")
                {
                    SwitchLower("BasePants");
                }
                if (ReturnActiveLower() == "EnglandPant")
                {
                    SwitchLower("RomenPants");
                }
                if (ReturnActiveLower() == "CowboyPants")
                {
                    SwitchLower("EnglandPant");
                }
                if (ReturnActiveLower() == "DiscoPants")
                {
                    SwitchLower("CowboyPants");
                }
                if (ReturnActiveLower() == "SuitPant")
                {
                    SwitchLower("DiscoPants");
                }
            }
            if(ReturnActiveUpper()==null && ReturnActiveLower() =="BasePants" && ReturnActiveHat() =="BaseHat")
            {
                
                if (ReturnActiveBoot() == "RomenShoe")
                {
                    Boots[0].SetActive(false);
                }
                if (ReturnActiveBoot() == "EnglandShoe")
                {
                    SwitchBoot("RomenShoe");
                }
                if (ReturnActiveBoot() == "CowboyShoe")
                {
                    SwitchBoot("EnglandShoe");
                }
                if (ReturnActiveBoot() == "DiscoShoe")
                {
                    SwitchBoot("CowboyShoe");
                }
                if (ReturnActiveBoot() == "SuitShoe")
                {
                    SwitchBoot("DiscoShoe");
                }

            }
        }
    }


}
