using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlaneNav : MonoBehaviour
{
    private Vector3 parkingLocation;
    public bool parkPlane;
    public bool startRoaming;
    Vector3 nextPosition;

    private NavMeshAgent navMeshAgent;

    public SpawnData spawnData;


    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;

    }

    private void Start()
    {
        parkingLocation = AssignHangerToPlane();
        nextPosition = transform.position;
    }

    private void GameManagerOnGameStateChanged(Gamestate gamestate)
    {
        if (gamestate == Gamestate.Park)
        {
            parkPlane = true;
        }

        if (gamestate == Gamestate.Roam) 
        {
            startRoaming = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (parkPlane) 
        {
            //moveToLocation = Hangar.transform;
            navMeshAgent.destination = parkingLocation;
        }

        if (startRoaming)
        {
            if (Vector3.Distance(nextPosition, transform.position) <= 1.5f) 
            {
                nextPosition = NewMovePosition(transform.position, 30);
                navMeshAgent.destination = nextPosition;
            }
        }

    }


    private Vector3 AssignHangerToPlane()
    {
        var hangars = GameObject.FindGameObjectsWithTag("Hangar");
        var hangarLocation = hangars[Random.Range(0, hangars.Length)].transform.position;
        return hangarLocation;
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

    public void ParkPlaneEvent(bool parkEventIsTriggered) 
    {
        parkPlane = parkEventIsTriggered;
    }
}
