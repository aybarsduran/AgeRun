using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    
    public GameObject menuTapToPlayElement;
    public GameObject modernityBar;
    public GameObject restartButton;
    public GameObject nextLevelButton;




    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged; //subscribe
    }

   

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;//unsubscribe
    }
    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {
        menuTapToPlayElement.SetActive(state == GameManager.GameState.Pre);
        modernityBar.SetActive(state == GameManager.GameState.Running);
        restartButton.SetActive(state == GameManager.GameState.Running|| state==GameManager.GameState.End);
      
       
    }
    private void Start()
    {
       
    }

    public void TapToPlayPressed()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Running);
       
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void NextLevel()
    {
        throw new NotImplementedException();
    }
}
