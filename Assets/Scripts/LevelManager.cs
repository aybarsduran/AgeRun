using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
    
{

    int random;
    private void Awake()
    {

       // PlayerPrefs.DeleteAll();
        
        print(PlayerPrefs.GetInt("level"));
        print(SceneManager.sceneCount);
        int targetlevel = PlayerPrefs.GetInt("level");
        if (SceneManager.GetActiveScene().buildIndex!=targetlevel)
        {
            SceneManager.LoadScene(targetlevel);
        }
        random = Random.Range(1, 5);




    }

    public void NextLevelButtonPressed()
    {
        if (PlayerPrefs.GetInt("level") == 4)
        {
            PlayerPrefs.SetInt("level", random);
            SceneManager.LoadScene(random);
        }
        else
        {
            PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    

       
    }
    
}
