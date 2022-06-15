using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarContoller : MonoBehaviour
{
    public Image image;

    int activeRomenCount;
    int activeEnglandCount;
    int activeCowboyCount;
    int activeDiscoCount;
    int activeSuitCount;

    int score;
    
    private void Start()
    {
        image = GetComponent<Image>();

        activeRomenCount = 0;
        activeEnglandCount = 0;
        activeCowboyCount = 0;
        activeDiscoCount = 0;
        activeSuitCount = 0;
        score = 0;
        
    }
  /* public void ChangeColor() 
    {
        
        image.color = Color.Lerp(image.color, Color.green, 0.1f);
        //image.color=Color.Lerp(image.color, Color.white, 0.5f);
    }*/
    // ne yapýcam ? = mesela o an aktif romalý sayýsýný bulucam

    public void IncreaseActiveRomenCount()
    {
        activeRomenCount++;
        activeCowboyCount--;
        activeEnglandCount--;
        activeDiscoCount--;
        activeSuitCount--;
    }
    public void IncreaseActiveEnglandCount()
    {
        activeRomenCount--;
        activeCowboyCount--;
        activeEnglandCount++;
        activeDiscoCount--;
        activeSuitCount--;
    }
    public void IncreaseActiveCowboyCount()
    {
        activeRomenCount--;
        activeCowboyCount++;
        activeEnglandCount--;
        activeDiscoCount--;
        activeSuitCount--;
    }
    public void IncreaseActiveDiscoCount()
    {
        activeRomenCount--;
        activeCowboyCount--;
        activeEnglandCount--;
        activeDiscoCount++;
        activeSuitCount--;
    }
    public void IncreaseActiveSuitCount()
    {
        activeRomenCount--;
        activeCowboyCount--;
        activeEnglandCount--;
        activeDiscoCount--;
        activeSuitCount++;
    }
    /*public void CompareClothes(string hatTag, string upperTag, string lowerTag, string bootTag)
    {

      
            //HATS
            if (hatTag == "RomenHat")
            {
            score += 1;
            }
            if (hatTag == "EnglandHat")
            {
            score += 10;
                
            }
            if (hatTag == "CowboyHat")
            {
            score += 100;
            }
            if (hatTag == "DiscoHat")
            {
            score += 1000;
            }
            if (hatTag == "SuitSunglass")
            {
            score += 10000;
            }
            //UPPER
            if (upperTag == "RomenShirt")
            {
               
            }
            if (upperTag == "EnglandShirt")
            {
               
            }
            if (upperTag == "CowboyShirt")
            {
                
            }
            if (upperTag == "DiscoShirt")
            {
                
            }
            if (upperTag == "SuitShirt")
            {
                
            }
            //LOWER
            if (lowerTag == "RomenPants")
            {
              
            }
            if (lowerTag == "EnglandPant")
            {
              
            }
            if (lowerTag == "CowboyPants")
            {
               
            }
            if (lowerTag == "DiscoPants")
            {
               
            }
            if (lowerTag == "SuitPant")
            {
                
            }

            //BOOT

            if (bootTag == "RomenShoe")
            {
                
            }
            if (bootTag == "EnglandShoe")
            {
                activeEnglandCount++;
            }
            if (bootTag == "CowboyShoe")
            {
                score += 1f;
            }
            if (bootTag == "DiscoShoe")
            {
                score += 1.5f;
            }
            if (bootTag == "SuitShoe")
            {
                score += 2f;
            }



        }

    }*/
}
