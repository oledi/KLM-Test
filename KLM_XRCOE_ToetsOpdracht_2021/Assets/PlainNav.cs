using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlainNav : MonoBehaviour
{
    [SerializeField] private Transform moveToLocation;
    public bool parkPlains;

    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parkPlains) //Input.GetKeyDown(KeyCode.Space)
        {
            navMeshAgent.destination = moveToLocation.position;
        }
    }

    public void ParkPlainsEvent(bool parkEventIsTriggered) 
    {
        parkPlains = parkEventIsTriggered;
    }
}
