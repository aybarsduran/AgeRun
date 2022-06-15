using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Animator Player;

    public GameObject starterEndSection;

    public ParticleSystem wind;

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
                HandleEndState();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState),newState,null);
        }

        OnGameStateChanged?.Invoke(newState);//event
    }

    private void HandleEndState()
    {
        starterEndSection.SetActive(false);
        wind.Pause();
    }

    private void HandleRunningState()
    {

        Player.SetBool("isWalking", true);
        wind.Play();
    }

    private void HandlePreState()
    {
        
    }
    private void Update()
    {
       
    }
}
