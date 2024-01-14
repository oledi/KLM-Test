using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public Gamestate state;

    public static event Action<Gamestate> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        UpdateGameState(Gamestate.StartMenu);
    }

    public void UpdateGameState(Gamestate newState)
    {
        state = newState;

        switch (newState) {
            case Gamestate.StartMenu:
                break;
            case Gamestate.Roam:
                    break;
            case Gamestate.Park:
                    break;
            case Gamestate.TurnOnLights:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void RoamPlains()
    {
        throw new NotImplementedException();
    }

}

public enum Gamestate
{
    StartMenu,
    Roam,
    Park,
    TurnOnLights
}