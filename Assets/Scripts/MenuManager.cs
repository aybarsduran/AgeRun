using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    
    public GameObject menuTapToPlayElement;
   
   


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
       
    }
    private void Start()
    {
       
    }

    public void TapToPlayPressed()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Running);
       
        
    }
}
