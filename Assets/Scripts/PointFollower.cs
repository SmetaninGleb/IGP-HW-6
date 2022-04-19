using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PointFollower : MonoBehaviour
{
    [SerializeField] private Transform _point;
    private NavMeshAgent _agent;

    public void SetPoint(Transform newPoint)
    {
        _point = newPoint;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(_point.position);
    }
}
