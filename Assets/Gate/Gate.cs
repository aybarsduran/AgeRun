using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{


    public GateType type;
    public enum GateType
    {
        Hats,
        UpperBody,
        LowerBody,
        Boots
    }
    public GameObject[] hatImages;
    public GameObject[] upperImages;
    public GameObject[] lowerImages;
    public GameObject[] bootImages;



    int random;
    int random2;
    int random3;
    int random4;



    private void Start()
    {
       
        if (type == GateType.Hats)
        {
            foreach (var imagehats in hatImages)
            {
                imagehats.SetActive(false);
            }

            random = Random.Range(0, 5);
            hatImages[random].SetActive(true);

        }
        if (type == GateType.UpperBody)
        {
            foreach(var imageupper in upperImages)
            {
                imageupper.SetActive(false);
            }
            random2 = Random.Range(0, 5);
            upperImages[random2].SetActive(true);
           
        }
       
       
        if (type == GateType.LowerBody)
        {
            foreach(var imagelower in lowerImages)
            {
                imagelower.SetActive(false);
            }

            random3 = Random.Range(0, 5);
            lowerImages[random3].SetActive(true);

        }
        if (type == GateType.Boots)
        {
            foreach(var imageboot in bootImages)
            {
                imageboot.SetActive(false);
            }
            random4 = Random.Range(0, 5);
            bootImages[random4].SetActive(true);

        }

      




    }

   
    public string returnHatTag()
    {
        return hatImages[random].tag;
    }
    public string returnUpperTag()
    {
        return upperImages[random2].tag;
    }
    public string returnLowerTag()
    {
        return lowerImages[random3].tag;
    }
    public string returnBootTag()
    {
        return bootImages[random4].tag;
    }
}
