using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeWaypointPath : MonoBehaviour
{
    public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }

    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = Random.Range(0, transform.childCount);
        
        return nextWaypointIndex;
    }
}
