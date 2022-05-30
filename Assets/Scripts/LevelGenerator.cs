using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject section;

    public int zPos=60;
    public bool creatingSection = false;

    public GameManager gameManager;
   

    // Update is called once per frame
    void Update()
    {
        if (!creatingSection && gameManager.state==GameManager.GameState.Running)
        {
            creatingSection=true;
            StartCoroutine(CreateSection());
        }
        
    }
    public IEnumerator CreateSection()
    {
        
        Instantiate(section,new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 60; 
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}

