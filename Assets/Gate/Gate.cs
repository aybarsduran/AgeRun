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



    private void Start()
    {
        //Randomu aynı kullandım sorun olur mu ?
        if (type == GateType.Hats)
        {

            random = Random.Range(0, 2);
            hatImages[random].SetActive(true);

        }
        if (type == GateType.UpperBody)
        {

            random = Random.Range(0, 2);
            upperImages[random].SetActive(true);
           
        }
       
       
        if (type == GateType.LowerBody)
        {

            random = Random.Range(0, 2);
            lowerImages[random].SetActive(true);

        }
        if (type == GateType.Boots)
        {

            random = Random.Range(0, 2);
            bootImages[random].SetActive(true);

        }

      




    }

    public string returnBootTag()
    {
       return bootImages[random].tag;
    }
    public string returnHatTag()
    {
        return hatImages[random].tag;
    }
    public string returnUpperTag()
    {
        return upperImages[random].tag;
    }
    public string returnLowerTag()
    {
        return lowerImages[random].tag;
    }
}
