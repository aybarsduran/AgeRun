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

    float detectionScore;

    float romenCount;
    float englandCount;
    float cowboyCount;
    float discoCount;
    float suitCount;

   
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
        detectionScore = 1;
        
        
    }
    private void Update()
    {


       



    }
    public void CalculateAge(string hatTag, string upperTag, string lowerTag, string bootTag)
    {
        float romenCount = 0;
        float englandCount = 0;
        float cowboyCount = 0;
        float discoCount = 0;
        float suitCount = 0;


        //HATS
        if (hatTag == "RomenHat")
        {
            romenCount++;
        }
        if (hatTag == "EnglandHat")
        {
            englandCount++;

        }
        if (hatTag == "CowboyHat")
        {
            cowboyCount++;

        }
        if (hatTag == "DiscoHat")
        {
            discoCount++;
        }
        if (hatTag == "SuitSunglass")
        {
            suitCount++; 
        }
        //UPPER
        if (upperTag == "RomenShirt")
        {
            romenCount++;
        }
        if (upperTag == "EnglandShirt")
        {
            englandCount++;
        }
        if (upperTag == "CowboyShirt")
        {
            cowboyCount++;
        }
        if (upperTag == "DiscoShirt")
        {
            discoCount++;
        }
        if (upperTag == "SuitShirt")
        {
            suitCount++;
        }
        //LOWER
        if (lowerTag == "RomenPants")
        {
            romenCount++;
        }
        if (lowerTag == "EnglandPant")
        {
            englandCount++;
        }
        if (lowerTag == "CowboyPants")
        {
            cowboyCount++;
        }
        if (lowerTag == "DiscoPants")
        {
            discoCount++;
        }
        if (lowerTag == "SuitPant")
        {
            suitCount++;
        }

        //BOOT

        if (bootTag == "RomenShoe")
        {
            romenCount++;
        }
        if (bootTag == "EnglandShoe")
        {
            englandCount++;
        }
        if (bootTag == "CowboyShoe")
        {
            cowboyCount++;
        }
        if (bootTag == "DiscoShoe")
        {
            discoCount++;
        }
        if (bootTag == "SuitShoe")
        {
            suitCount++;
        }


        if (suitCount >= 1 && discoCount <= 1 && romenCount <= 1 && englandCount <= 1 && cowboyCount <= 1)
        {
            SetUIText("2020's");
        }
        if (discoCount >= 2 && suitCount <=1)
        {
            if (discoCount >= 2)
            {
                SetUIText("70's");
            }
        }
        
        

      

    


    }
    public void SetUIText(string agetext)
    {
        
        text.text = agetext;
        


    }
    public void UpdateProgressFill(float value)
    {
        fillImage.fillAmount = value/100;
    }
    //suitler 
    public float CalculateValue(string hatTag, string upperTag, string lowerTag, string bootTag)
    {
        CalculateAge(hatTag, upperTag, lowerTag, bootTag);
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
            hatValue = 24f;
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
            chestValue = 24f;
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
            lowerValue = 24f;
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
            bootValue = 24f;
        }


        return hatValue+chestValue+bootValue+lowerValue;

    }








}
