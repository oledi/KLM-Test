using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuPanel, numberOfPlains;


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


    public void OnEntryNumberOfPlains() {
        GameManager.Instance.UpdateGameState(Gamestate.Roam);
    }

    public void ParkAllPlains() {
        GameManager.Instance.UpdateGameState(Gamestate.Park);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
