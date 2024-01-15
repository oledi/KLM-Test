using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlainNav : MonoBehaviour
{
    [SerializeField] private Transform moveToLocation;
    public bool parkPlains;
    public bool startRoaming;
    Vector3 nextPosition;

    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;

    }

    private void Start()
    {
        nextPosition = transform.position;
    }

    private void GameManagerOnGameStateChanged(Gamestate gamestate)
    {
        if (gamestate == Gamestate.Park)
        {
            parkPlains = true;
        }

        if (gamestate == Gamestate.Roam) 
        {
            startRoaming = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (parkPlains) //Input.GetKeyDown(KeyCode.Space)
        {
            navMeshAgent.destination = moveToLocation.position;
        }

        if (startRoaming)
        {
            if (Vector3.Distance(nextPosition, transform.position) <= 1.5f) 
            {
                nextPosition = NewMovePosition(transform.position, 30);
                navMeshAgent.destination = nextPosition;
               // navMeshAgent.destination = new Vector3(0, 0, 0);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, nextPosition);
    }

    public Vector3 NewMovePosition(Vector3 startPoint, float radius) 
    {
        Vector3 dir = Random.insideUnitSphere * radius;
        dir += startPoint;
        NavMeshHit Hit;
        Vector3 Final_Pos = Vector3.zero;
        if (NavMesh.SamplePosition(dir, out Hit, radius, 1)) 
        {
            Final_Pos = Hit.position;
        }
        return Final_Pos;
    }

    public void ParkPlainsEvent(bool parkEventIsTriggered) 
    {
        parkPlains = parkEventIsTriggered;
    }
}
