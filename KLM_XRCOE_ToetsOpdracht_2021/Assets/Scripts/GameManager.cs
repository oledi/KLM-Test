using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject airplane;
    public GameObject Hangar;

    private int NumberOfPlains;
    private int NumberOfHangars;
    public List<string> PlainNames;
    public string[] PlainTypes;

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
                InstantiateHangars();
                InstantiatePlains();
                    break;
            case Gamestate.Park:
                    break;
            case Gamestate.TurnOnLights:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void InstantiatePlains()
    {
        for(var i=0; i< NumberOfPlains; i++) {

            var newplain = Instantiate(airplane, new Vector3((i-1.5f) * 2.0f, 0, 0), Quaternion.identity);

            string name = PlainNames[UnityEngine.Random.Range(0, PlainNames.Count)];
            PlainNames.Remove(name);
            newplain.name = name;
            newplain.tag = PlainTypes[UnityEngine.Random.Range(0, PlainTypes.Length)];
        }
    }

    private void InstantiateHangars() {
        for(var i = 0; i < NumberOfHangars; i++)
        {
            var NewHangar  = Instantiate(Hangar, new Vector3((i-1.5f) * 2.0f, 1.78814e-07f, 2.54f), Quaternion.identity);
            NewHangar.name = "Hangar" + i;
        }
    }

    public void OnEntryNumberOfPlains(string numberOfPlains)
    {
        NumberOfPlains = int.Parse(numberOfPlains); //Of restricties zetten op input field of TryParse. or both! both is good :D
    }

    public void OnEntryNumberOfHangars(string numberOfHangars)
    {
        NumberOfHangars = int.Parse(numberOfHangars); //Of restricties zetten op input field of TryParse. or both! both is good :D
        GameManager.Instance.UpdateGameState(Gamestate.Roam);
    }

}

public enum Gamestate
{
    StartMenu,
    Roam,
    Park,
    TurnOnLights
}