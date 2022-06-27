using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject section;
    public GameObject endSection;

   

    public float zPos;
    public bool creatingSection = false;

    public GameManager gameManager;
    public static int sectionCount;

    private void Start()
    {
        sectionCount = 0;
      
    }


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
        if (gameManager.levelCount > 0) { 
        Instantiate(section, new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 120.15f;
        sectionCount++; }
        if (sectionCount < gameManager.levelCount)
        {
            yield return new WaitForSeconds(3);
            creatingSection = false;
        }
        else
        {
            Instantiate(endSection,new Vector3(0,0,zPos-57),Quaternion.identity);
            
        }

    }
}

