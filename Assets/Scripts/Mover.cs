using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    private int _currentWaypoint = 0;
    private float _distanceToTarget = 0.1f;

    public void Move()
    {
        if (transform.position.IsEnoughClose(_waypoints[_currentWaypoint].position, _distanceToTarget))
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}