using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
[SerializeField] private WayCreator WayCreator;
[SerializeField] private int WayID;
[SerializeField] private float SmoothingMoveSpeed;


void Start()
{
int RandomId = Random.Range(0,WayCreator.Waypoints.Count);
WayID = WayCreator.Waypoints[RandomId].WaypointID;
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
      gameObject.transform.position = SelectedWaypoint.gameObject.transform.position;  
    }
    else
    {
      Debug.LogError("NERABOTAET");
    }
   
  }
}

}
