using System.Collections.Generic;
using UnityEngine;

public class WayCreator : MonoBehaviour
{
    [SerializeField] private WayCreatorSettings Settings;
    [SerializeField] private GameObject WaypointObject;
    [SerializeField] private bool CreationDebug = true;
    [SerializeField] private bool GenerateOnStartScene = true; //if off, way generate from code
    public List<WaypointCollection> Waypoints;

[System.Serializable]
public class WaypointCollection
{
    public int WaypointID = 0;
    public Waypoint WaypointScript;
}

    void Awake()
    { 
        if(GenerateOnStartScene == true)
        {
        GenerateWay();
        }
    }
    public void GenerateWay()
    {
        if(Settings)
        {
        Waypoints.Clear();
        if(CreationDebug)
        {
        Debug.Log("Creating way");
        }
        for(int i = 0; i < Settings.Waypoints.Count; i++)
        {
            GameObject CreatedWaypoint = Instantiate(WaypointObject,new Vector3(Settings.Waypoints[i]._WaypointPosition.x, Settings.Waypoints[i]._WaypointPosition.y, Settings.Waypoints[i]._WaypointPosition.z) ,Quaternion.identity);
            Waypoint WaypointObjectScript = CreatedWaypoint.GetComponent<Waypoint>();
            WaypointObjectScript.ChangeWaypointID(Settings.Waypoints[i]._WaypointID);
            WaypointObjectScript.ChangePanicWeight(Settings.Waypoints[i]._PanicWeight);
            WaypointObjectScript.ChangeCanInteract(Settings.Waypoints[i]._CanInteract);
            CreatedWaypoint.transform.SetParent(gameObject.transform, false);

            WaypointCollection CreatedWaypointItem = new WaypointCollection();
            CreatedWaypointItem.WaypointID = Settings.Waypoints[i]._WaypointID;
            CreatedWaypointItem.WaypointScript = WaypointObjectScript;
            
            Waypoints.Add(CreatedWaypointItem);
        }
        }
        else{
        Debug.LogWarning("Settings not assigned");
        }
    }

    public void GetWaypointByID(int ID)
    {
        for(int i = 0; i < Waypoints.Count; i++)
        {
            if(Waypoints[i].WaypointID == ID)
            {
                print(Waypoints[i].WaypointID);
            }
        }
        
    }

 
    
}
