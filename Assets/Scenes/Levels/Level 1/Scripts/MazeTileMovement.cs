using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTileMovement : MonoBehaviour
{
    [SerializeField]
    private MazeTileWaypoints waypointPath;

    private float speed = 4;

    private int targetWaypointIndex;

    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;
    private float waitTimer;
    private float waitDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
       TargetNextWaypoint(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float elapedPercentage = elapsedTime / timeToWaypoint;
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapedPercentage);

        if (elapedPercentage >= 1)
        {
            if(previousWaypoint == waypointPath.GetWaypoint(0) && targetWaypoint == waypointPath.GetWaypoint(0))
                waitDuration = 30f;
            else if(previousWaypoint == waypointPath.GetWaypoint(2) || previousWaypoint == waypointPath.GetWaypoint(0))
                waitDuration = 5f;
            else if(previousWaypoint == waypointPath.GetWaypoint(1))
                waitDuration = 15f;

            waitTimer += Time.deltaTime;
            if(waitTimer > waitDuration)
            {
                waitTimer = 0;
                TargetNextWaypoint();
            }
        }
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        if(previousWaypoint != waypointPath.GetWaypoint(0) && waypointPath.GetWaypoint(targetWaypointIndex) != waypointPath.GetWaypoint(0))
        {
            targetWaypointIndex = 0;
            targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        }
        else
            targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damageable")
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Damageable")
        {
            other.transform.SetParent(null);
        }
    }
}
