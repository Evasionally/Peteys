using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private MazeWaypointPath _waypointPath;

    
    private float _speed = 4;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;
    private float _waitTimer;
    private float _waitDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
       TargetNextWaypoint(); 
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        float elapedPercentage = _elapsedTime / _timeToWaypoint;
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapedPercentage);

        if (elapedPercentage >= 1)
        {
            if(_previousWaypoint == _waypointPath.GetWaypoint(0) && _targetWaypoint == _waypointPath.GetWaypoint(0))
                _waitDuration = 30f;
            else if(_previousWaypoint == _waypointPath.GetWaypoint(2) || _previousWaypoint == _waypointPath.GetWaypoint(0))
                _waitDuration = 5f;
            else if(_previousWaypoint == _waypointPath.GetWaypoint(1))
                _waitDuration = 15f;

            _waitTimer += Time.deltaTime;
            if(_waitTimer > _waitDuration)
            {
                _waitTimer = 0;
                TargetNextWaypoint();
            }
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        if(_previousWaypoint != _waypointPath.GetWaypoint(0) && _waypointPath.GetWaypoint(_targetWaypointIndex) != _waypointPath.GetWaypoint(0))
        {
            _targetWaypointIndex = 0;
            _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        }
        else
            _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }
}
