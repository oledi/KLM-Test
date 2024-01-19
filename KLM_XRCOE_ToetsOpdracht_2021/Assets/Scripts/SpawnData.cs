using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnData", order = 1)]
public class SpawnData : ScriptableObject
{
    public List<string> PlaneNames;
    public string[] PlaneTypes;
    public List<Vector3> PlaneSpawnPoints;
    public List<Vector3> HangarSpawnPoints;
    public List<Vector3> HangarSpawnRotations;
    public Transform[] RunwayEndLocation;
}
