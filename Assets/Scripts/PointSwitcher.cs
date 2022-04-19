using System.Collections.Generic;
using UnityEngine;

public class PointSwitcher : MonoBehaviour
{
    private const float ZERO_DISTANCE_CLAMP = 0.8f;

    [SerializeField] private PointFollower _follower;
    [SerializeField] private List<Transform> _pointList;
    private int _currentPointIndex;

    private void Start()
    {
        foreach (Transform pointTrans in _pointList)
        {
            pointTrans.gameObject.SetActive(false);
        }
        _currentPointIndex = Random.Range(0, _pointList.Count);
        Transform _currentPointTransform = _pointList[_currentPointIndex].transform;
        _currentPointTransform.gameObject.SetActive(true);
        _follower.SetPoint(_currentPointTransform);
    }

    private void Update()
    {
        Vector3 _pointPos = _pointList[_currentPointIndex].transform.position;
        Vector3 _followerPos = _follower.transform.position;
        if (Vector3.Distance(_pointPos, _followerPos) <= ZERO_DISTANCE_CLAMP)
        {
            ChangePoint();
        }
    }
    
    private void ChangePoint()
    {
        int newPointIndex = _currentPointIndex;
        while (newPointIndex == _currentPointIndex)
        {
            newPointIndex = Random.Range(0, _pointList.Count);
        }
        _pointList[_currentPointIndex].gameObject.SetActive(false);
        Transform newPoint = _pointList[newPointIndex];
        newPoint.gameObject.SetActive(true);
        _follower.SetPoint(newPoint);
        _currentPointIndex = newPointIndex;
    }
}