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
        romenCount = 0;
        englandCount = 0;
        cowboyCount = 0;
        discoCount = 0;
        suitCount = 0;

        hatValue = 0;
        chestValue = 0;
        lowerValue = 0;
        bootValue = 0;

        text.text = "Stone Age";
        UpdateProgressFill(0);
        detectionScore = 1;


    }
    private void Update()
    {

        print(romenCount + "Romen");
        print(englandCount + "en");
        print(cowboyCount + "cow");
        print(discoCount + "dis");
        print(suitCount + "suit");



    }
    public void CalculateAge(string hatTag, string upperTag, string lowerTag, string bootTag)
    {

        romenCount = 0;
        englandCount = 0;
        cowboyCount = 0;
        discoCount = 0;
        suitCount = 0;

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
        if (suitCount == 2 && (cowboyCount == 2 || englandCount == 2 || romenCount == 2))
        {
            SetUIText("2020's");
        }
        if (discoCount == 2 && suitCount == 2)
        {
            SetUIText("2020's");
        }

      
        if(discoCount>1 && suitCount<=1 && cowboyCount<=1 && englandCount<=1 && romenCount <= 1)
        {
            SetUIText("70's");
        }
        if(cowboyCount==2 && discoCount == 2)
        {
            SetUIText("70's");

        }

        if(cowboyCount>1 && discoCount<=1 && suitCount<=1 && englandCount<=1&& romenCount <= 1)
        {
            SetUIText("Cowboy Era");
        }
        if(englandCount==2&& cowboyCount == 2)
        {
            SetUIText("Cowboy Era");

        }
      
        if(englandCount>1 && discoCount<=1 && suitCount<=1&& cowboyCount<=1 && romenCount <= 1)
        {
            SetUIText("1700's");
        }
        if(romenCount==2&& englandCount == 2)
        {
            SetUIText("1700's");
        }
        if(romenCount>1 && discoCount <=1 && suitCount<=1 && cowboyCount<=1 && englandCount <=1)
        {
            SetUIText("Roman Age");
        }



        if (romenCount >= 1 && discoCount ==0 && suitCount ==0 && cowboyCount ==0&& englandCount ==0)
        {
            SetUIText("Roman Age");
        }
        if (englandCount >= 1 && discoCount ==0 && suitCount ==0 && cowboyCount==0 && romenCount==0)
        {
            SetUIText("1700's");
        }
        if (cowboyCount >= 1 && discoCount ==0 && suitCount ==0 && englandCount ==0 && romenCount ==0)
        {
            SetUIText("Cowboy Era");
        }
        if (discoCount >= 1 && suitCount==0 && cowboyCount ==0 && englandCount ==0 && romenCount ==0)
        {
            SetUIText("70's");
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
            hatValue = 18f;
        }
        if (hatTag == "SuitSunglass")
        {
            hatValue = 22f;
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
            chestValue = 18f;
        }
        if (upperTag == "SuitShirt")
        {
            chestValue = 22f;
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
            lowerValue = 18f;
        }
        if (lowerTag == "SuitPant")
        {
            lowerValue = 22f;
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
            bootValue = 18f;
        }
        if (bootTag == "SuitShoe")
        {
            bootValue = 22f;
        }


        return hatValue+chestValue+bootValue+lowerValue;

    }








}
