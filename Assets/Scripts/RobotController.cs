using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    public Transform[] waypoints;
    public int destinationPoint = 0;
    public GameObject player;
    public Transform playerNavCheck;
    public Vector3 relPlayerPos;
    public NavMeshAgent robot;
    public Light spotlight;
    public Color undetectedColor;
    public bool detectPlayer = false;
    public Transform lineOfSight;
    public MeshCollider areaOfSight;

    void Start()
    {
        undetectedColor = spotlight.color;
        GoToNextWaypoint();
    }

    private void FixedUpdate()
    {
        if (!robot.pathPending && robot.remainingDistance < 0.1f && detectPlayer == false)
        {
            GoToNextWaypoint();
        }

        if (detectPlayer == true)
        {
            Chase();
        }
        else

            WindDown();

        if (transform.position == player.transform.position)
        {
            GameManager.Instance.playerHealth = 0;
        }
    }

    void GoToNextWaypoint()
    {
        spotlight.color = (undetectedColor);
        if(waypoints.Length == 0)
        { 
            return;
        }
        else
        robot.destination = waypoints[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % waypoints.Length;
    }
    void Chase()
    {
        spotlight.color = (Color.red);
        robot.SetDestination(player.transform.position);
    }

    void WindDown()
    {
        GameManager.Instance.isDetected = false;
        detectPlayer = false;
        spotlight.color = (undetectedColor);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            //Debug.Log("Inside View");
            NavMeshHit navHit;
            if (NavMesh.SamplePosition(playerNavCheck.transform.position, out navHit, 10f, NavMesh.AllAreas))
            {
                //Debug.Log("On Mesh");
                relPlayerPos = player.transform.position - lineOfSight.position;
                RaycastHit rayHit;
                if (Physics.Raycast(lineOfSight.position, relPlayerPos, out rayHit))
                {
                    if (rayHit.collider.gameObject == player)
                    {
                        //Debug.Log("Direct Line of Sight");
                        GameManager.Instance.isDetected = true;
                        detectPlayer = true;
                        GameManager.Instance.RobotDetectSound();
                        Chase();
                    }
                    //else WindDown();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(lineOfSight.position, relPlayerPos);
    }
}
