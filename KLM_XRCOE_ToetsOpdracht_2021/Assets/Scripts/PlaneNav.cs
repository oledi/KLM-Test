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

    private Vector3 startRunwayLocation;
    private Vector3 endRunwayLocation;

    private float groundLevel = 2f;
    private float skyLevel = 8f;
    private float graceDistance = 1f;
    private float randomPositionRadius = 30f;


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
        AssignRunwayToPlane();
        navMeshAgent.destination = startRunwayLocation;
        parkingLocation = AssignHangerToPlane();
        nextPosition = endRunwayLocation;
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
            navMeshAgent.destination = parkingLocation;
        }

        if (startRoaming)
        {

            if (!navMeshAgent.pathPending && !parkPlane && gameObject.transform.position.y <= groundLevel)
            {
                if (navMeshAgent.remainingDistance < graceDistance) 
                {
                    navMeshAgent.destination = endRunwayLocation;
                }
            }

            if (gameObject.transform.position.y >= skyLevel)
            {
                if (Vector3.Distance(nextPosition, transform.position) <= graceDistance)
                {
                    nextPosition = NewMovePosition(transform.position, randomPositionRadius);
                    navMeshAgent.destination = nextPosition;
                }
            }
        }

    }

    private void AssignRunwayToPlane() {
        var randomNumber = Random.Range(0, spawnData.RunwayStartLocation.Length);
        startRunwayLocation = spawnData.RunwayStartLocation[randomNumber];
        endRunwayLocation = spawnData.RunwayEndLocation[randomNumber];
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
        Vector3 dir = Random.insideUnitCircle * radius;
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
