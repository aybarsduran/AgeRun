using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ElephantSDK;
public class LevelManager : MonoBehaviour
{
    int random;
    int lastLevelReached;
    private void Awake()
    {
        DynamicGI.UpdateEnvironment();
        //PlayerPrefs.DeleteAll();



        int targetlevel = PlayerPrefs.GetInt("level");
        if (SceneManager.GetActiveScene().buildIndex!=targetlevel)
        {
            SceneManager.LoadScene(targetlevel);
        }
        random = Random.Range(1, 6);
        if (!PlayerPrefs.HasKey("lastLevelReached")){
            PlayerPrefs.SetInt("lastLevelReached", SceneManager.GetActiveScene().buildIndex);
        }
        lastLevelReached = PlayerPrefs.GetInt("lastLevelReached");
        Debug.Log("Awakede " + lastLevelReached);


    }
    private void OnEnable()
    {
        DynamicGI.UpdateEnvironment();
        Elephant.LevelStarted(lastLevelReached);
        Debug.Log("enable " + lastLevelReached);


    }
    public void NextLevelButtonPressed()
    {
        Elephant.LevelFailed(lastLevelReached);
        PlayerPrefs.SetInt("lastLevelReached", lastLevelReached + 1);
        Debug.Log("next" + lastLevelReached);

        if (PlayerPrefs.GetInt("level") == 5)
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
