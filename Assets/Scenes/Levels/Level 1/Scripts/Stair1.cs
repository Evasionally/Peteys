using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair1 : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float waitDuration = 0;

    private float waitTimer;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waitTimer += Time.deltaTime;
        if(waitTimer > waitDuration)
        {

            _elapsedTime += Time.deltaTime;

            float elapedPercentage = _elapsedTime / _timeToWaypoint;
            transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapedPercentage);

            if (elapedPercentage >= 1)
            {
                TargetNextWaypoint();
            }
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
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
