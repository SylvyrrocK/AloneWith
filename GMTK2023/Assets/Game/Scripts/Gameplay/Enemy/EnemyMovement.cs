using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
[SerializeField] private PlayerStats PSTST;


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
PSTST.isActive = false;
}

public void WalkTo(Vector3 WalkPosition, bool Smooth)
{
  PSTST.isActive = true;
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
    if(Vector3.Distance(SelectedWaypoint.gameObject.transform.position, gameObject.transform.position)<1)
    {
    
    TryIDWay = WayID;
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
