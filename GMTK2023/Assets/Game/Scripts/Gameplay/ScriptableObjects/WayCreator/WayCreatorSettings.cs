using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WayCreatorSettings", menuName = "WayCreatorSettings", order = 51)]
public class WayCreatorSettings : ScriptableObject
{
public List<WaypointsSettings> Waypoints;
[System.Serializable]
public class WaypointsSettings
{
    public int _WaypointID = 0;
    public Vector3 _WaypointPosition;
    [Range (0.0f, 10f)]public float _PanicWeight = 1.0f;
    public List<GameObject> _CanInteract = new List<GameObject>();
}

}
