using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SpawnData spawnData;
    public GameObject airplane;
    public GameObject Hangar;

    private int NumberOfPlains;
    private int NumberOfHangars;

    public Gamestate state;

    public RaycastHit raycastHit;
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

            var spawnpoint = spawnData.PlaneSpawnPoints[UnityEngine.Random.Range(0, spawnData.PlaneSpawnPoints.Count)];

            var newplain = Instantiate(airplane, spawnpoint, Quaternion.identity); 

            string name = spawnData.PlaneNames[i];

            newplain.name = name;
            newplain.tag = spawnData.PlaneTypes[UnityEngine.Random.Range(0, spawnData.PlaneTypes.Length)];
        }
    }

    private void InstantiateHangars() {
        for(var i = 0; i < NumberOfHangars; i++)
        {

            var NewHangar = Instantiate(Hangar, spawnData.HangarSpawnPoints[i], Quaternion.Euler(spawnData.HangarSpawnRotations[i]));

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