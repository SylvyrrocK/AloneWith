using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
[SerializeField] private WayCreator WayCreator;
[SerializeField] private int WayID;
[SerializeField] private float SmoothingMoveSpeed;
[SerializeField] private float WalkProgress;


void Start()
{
int RandomId = Random.Range(0,WayCreator.Waypoints.Count);
WayID = WayCreator.Waypoints[RandomId].WaypointID;
WalkTo(gameObject.transform.position, false);
}
void WalkTo(Vector3 WalkPosition, bool Smooth)
{
  Waypoint SelectedWaypoint = WayCreator.GetWaypointByID(WayID);

  if(Smooth == true){

  }
  else
  {
    if(SelectedWaypoint)
    {
      gameObject.transform.position = SelectedWaypoint.GetWaypointPosition(); 
      Debug.LogError(SelectedWaypoint.GetWaypointPosition());
    }
    else
    {
      Debug.LogError("NERABOTAET");
    }
   
  }
}

}
