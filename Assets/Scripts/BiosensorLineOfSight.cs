using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BiosensorLineOfSight : MonoBehaviour
{

    public GameObject player;
    public Transform pivotPoint;
    public Vector3 relPlayerPos;
    public Light spotlight;
    public Color undetectedColor;
    public bool detectPlayer = false;
    public Animator animator;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        undetectedColor = spotlight.color;

    }

    private void FixedUpdate()
    {
        if (detectPlayer == true)
        {
            GameManager.Instance.isDetectedBySensor = true;
            animator.enabled = false;
            spotlight.color = (Color.red);


            if (GameManager.Instance.isInvulnerable == false)
            {
                GameManager.Instance.playerHealth -= 1 * Time.deltaTime;
            }
        }
        else
            detectPlayer = false;
            GameManager.Instance.isDetectedBySensor = false;
            animator.enabled = true;
            spotlight.color = (undetectedColor);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            relPlayerPos = player.transform.position - pivotPoint.position;
            RaycastHit hit;

            if (Physics.Raycast(pivotPoint.position, relPlayerPos, out hit))
            {
                Debug.Log(hit.collider.gameObject.name.ToString());
                if (hit.collider.gameObject == player)
                {
                    detectPlayer = true;
                    GameManager.Instance.isDetectedBySensor = true;
                    animator.enabled = false;
                    spotlight.color = (Color.red);
                }
                else
                    detectPlayer = false;
            }   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            detectPlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(pivotPoint.position, relPlayerPos);
    }
}
