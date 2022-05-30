using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   public enum GameState
    {
        Pre,
        Running,
        End
    }

    public GameState state;


    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Pre);
    }

    public void UpdateGameState(GameState newState)
    {
        state=newState;


        switch (newState)
        {
            case GameState.Pre:
                HandlePreState();
                break;
            case GameState.Running:
                HandleRunningState();
                break;
            case GameState.End:
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState),newState,null);
        }

        OnGameStateChanged?.Invoke(newState);//event
    }

    private void HandleRunningState()
    {
        
    }

    private void HandlePreState()
    {
        
    }
}
