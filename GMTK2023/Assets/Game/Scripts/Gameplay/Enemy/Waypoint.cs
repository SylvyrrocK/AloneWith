using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
[Header("WAYPOINT SETTINGS")]
[SerializeField] private int WaypointID = 0;
[SerializeField] private bool IsSelected = false;
[Space (25)]
[SerializeField] [Range (0.0f, 10f)]private float PanicWeight = 1.0f;
[SerializeField] private List<GameObject> CanInteract = new List<GameObject>();

public void ChangeWaypointID(int newWaypointID){
    WaypointID = newWaypointID;
}
public void ChangePanicWeight(float newPanicWeight){
    PanicWeight = newPanicWeight;
}
public void ChangeCanInteract(List<GameObject> newCanInteract){
    CanInteract.Clear();
    CanInteract = newCanInteract;
}
}
