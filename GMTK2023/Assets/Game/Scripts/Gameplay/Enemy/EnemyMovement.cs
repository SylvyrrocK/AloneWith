using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
[SerializeField] private WayCreator WayCreator;
[SerializeField] private int WayID;

[SerializeField] private int TryIDWay;
[SerializeField] private int WalkToID;
[SerializeField] private float SmoothingMoveSpeed;
[SerializeField] private float WalkProgress;
[SerializeField] private PanicBar PanicBar;
[SerializeField] private Animator EnemyAnimator;


void Start()
{

}
public void Walk()
{
  EnemyAnimator.SetBool("WALK", true);
// int RandomId = Random.Range(0,WayCreator.Waypoints.Count);
// WayID = WayCreator.Waypoints[RandomId].WaypointID;
// WalkTo(gameObject.transform.position, false);

WalkProgress = WalkProgress + 0.5f * Time.deltaTime;
if(WalkProgress > 1&WalkProgress < 2)
{
  WalkToID = 1;
}
if(WalkProgress > 2&WalkProgress < 3)
{
  WalkToID = 2;
}
if(WalkProgress > 3)
{
  WalkToID = 3;
}
if(TryIDWay != WalkToID)
{
  WayID = WalkToID;
WalkTo(gameObject.transform.position, true);
}

}
public void Hide()
{
EnemyAnimator.SetBool("WALK", false);
}

public void WalkTo(Vector3 WalkPosition, bool Smooth)
{
  Waypoint SelectedWaypoint = WayCreator.GetWaypointByID(WayID);

  if(Smooth == true){
   if(SelectedWaypoint)
    {
      gameObject.transform.position = Vector3.Lerp (transform.position, SelectedWaypoint.GetWaypointPosition(), SmoothingMoveSpeed * Time.deltaTime); 
    }
    else
    {
      Debug.LogError("NERABOTAET");
    }
    if(gameObject.transform.position.x == SelectedWaypoint.GetWaypointPosition().x)
    {
    TryIDWay = SelectedWaypoint.GetWaypointID();
    PanicBar.ChangeValue(SelectedWaypoint.GetPanicWeight());
    }
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
    if(gameObject.transform.position == SelectedWaypoint.GetWaypointPosition())
    {
    TryIDWay = SelectedWaypoint.GetWaypointID();
    }
   
  }
}

}
