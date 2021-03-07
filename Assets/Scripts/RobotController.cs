using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public Transform[] waypoints;
    private int destinationPoint = 0;
    public GameObject playerNavCheck;
    public NavMeshAgent robot;

    void Start()
    {
        GoToNextWaypoint();
    }
    void Update()
    {
        if (!robot.pathPending && robot.remainingDistance < 0.5f)
        {
           GoToNextWaypoint();
        }
    }

    void GoToNextWaypoint()
    {
        if(waypoints.Length == 0)
        { 
            return;
        }
        robot.destination = waypoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % waypoints.Length;
    }
}
