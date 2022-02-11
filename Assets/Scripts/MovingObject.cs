using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private List<Vector3> _wayPoints;
    private int _currentPointIndex;

    [SerializeField] private float _movingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _currentPointIndex = 0;

        _wayPoints = new List<Vector3>();
        AddWayPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentPointIndex < _wayPoints.Count - 1)
        {
            float currentDistance = Vector3.Distance(_wayPoints[_currentPointIndex], _wayPoints[_currentPointIndex + 1]);
            float passedDistance = Vector3.Distance(_wayPoints[_currentPointIndex], transform.position);

            float fraction = (passedDistance + _movingSpeed * Time.deltaTime) / currentDistance;

            transform.position = Vector3.Lerp(_wayPoints[_currentPointIndex], _wayPoints[_currentPointIndex + 1], fraction);

            if (fraction >= 1.0f)
            {
                _currentPointIndex += 1;
            }
        }
    }
    
    public void AddWayPoint(Vector3 coords)
    {
        _wayPoints.Add(coords);
    }

    public void SetMovingSpeed(float newSpeed)
    {
        _movingSpeed = newSpeed;
    }
}
