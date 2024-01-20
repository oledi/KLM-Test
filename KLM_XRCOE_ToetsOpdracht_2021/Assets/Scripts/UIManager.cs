using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuPanel, numberOfPlanes;


    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;

    }

    private void GameManagerOnGameStateChanged(Gamestate gamestate) 
    {
        startMenuPanel.SetActive(gamestate == Gamestate.StartMenu);
    }


    public void ParkAllPlanes() {
        GameManager.Instance.UpdateGameState(Gamestate.Park);
    }

}
