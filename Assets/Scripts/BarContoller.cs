using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarContoller : MonoBehaviour
{
    public Image fillImage;
    public TextMeshProUGUI text;

    public Animator textAnim;
   


   
    float hatValue;
    float chestValue;
    float lowerValue;
    float bootValue;
    private void Start()
    {

        float hatValue = 0;
        float chestValue = 0;
        float lowerValue = 0;
        float bootValue = 0;

        text.text = "Stone Age";
        UpdateProgressFill(0);
        
        
    }
    private void Update()
    {
       
    }
    public void UITextDetection(string tag)
    {
        if(tag== "BaseHat" || tag=="BasePants")
        {
            SetUIText("Stone Age");
        }
        //Rome
        if (tag == "RomenHat" || tag == "RomenShirt" || tag == "RomenPants" || tag == "RomenShoe")
        {
            SetUIText("Roman Age");
        }
       
        //England
        if (tag == "EnglandHat" || tag == "EnglandShirt" || tag == "EnglandPant" || tag == "EnglandShoe" )
        {
            SetUIText("1700's");
        }
        //Cowboy
        if (tag == "CowboyHat" || tag == "CowboyShirt" || tag == "CowboyPants" || tag == "CowboyShoe")
        {
            SetUIText("1800's");
        }
        // Disco
        if (tag == "DiscoHat" || tag == "DiscoShirt" || tag == "DiscoPants" || tag == "DiscoShoe")
        {
            SetUIText("70's");
        }
        //Suit
        if (tag == "SuitSunglass" || tag == "SuitShirt" || tag == "SuitPant" || tag == "SuitShoe")
        {
            SetUIText("2020's");
        }
    }
    public void SetUIText(string agetext)
    {
        textAnim.SetTrigger("Fade");
        text.text = agetext;
        


    }
    public void UpdateProgressFill(float value)
    {
        fillImage.fillAmount = value/100;
    }
    //suitler 
    public float CalculateValue(string hatTag, string upperTag, string lowerTag, string bootTag)
    {
        //HATS
        if (hatTag == "RomenHat")
        {
            hatValue = 5f;
        }
        if (hatTag == "EnglandHat")
        {
            hatValue = 10f;
        }
        if (hatTag == "CowboyHat")
        {
            hatValue = 15f;
        }
        if (hatTag == "DiscoHat")
        {
            hatValue = 20f;
        }
        if (hatTag == "SuitSunglass")
        {
            hatValue = 25f;
        }
        //UPPER
        if (upperTag == "RomenShirt")
        {
            chestValue = 5f;
        }
        if (upperTag == "EnglandShirt")
        {
            chestValue = 10f;
        }
        if (upperTag == "CowboyShirt")
        {
            chestValue = 15f;
        }
        if (upperTag == "DiscoShirt")
        {
            chestValue = 20f;
        }
        if (upperTag == "SuitShirt")
        {
            chestValue = 25f;
        }
        //LOWER
        if (lowerTag == "RomenPants")
        {
            lowerValue = 5f;
        }
        if (lowerTag == "EnglandPant")
        {
            lowerValue = 10f;
        }
        if (lowerTag == "CowboyPants")
        {
            lowerValue = 15f;
        }
        if (lowerTag == "DiscoPants")
        {
            lowerValue = 20f;
        }
        if (lowerTag == "SuitPant")
        {
            lowerValue = 25f;
        }

        //BOOT

        if (bootTag == "RomenShoe")
        {
            bootValue = 5f;
        }
        if (bootTag == "EnglandShoe")
        {
            bootValue = 10f;
        }
        if (bootTag == "CowboyShoe")
        {
            bootValue = 15f;
        }
        if (bootTag == "DiscoShoe")
        {
            bootValue = 20f;
        }
        if (bootTag == "SuitShoe")
        {
            bootValue = 25f;
        }


        return hatValue+chestValue+bootValue+lowerValue;

    }








}
