using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiosensorLineOfSight : MonoBehaviour
{

    public GameObject player;
    public Transform pivotPoint;
    public Vector3 relPlayerPos;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("IN RANGE");
            relPlayerPos = player.transform.position - pivotPoint.position;
            RaycastHit hit;

            if (Physics.Raycast(pivotPoint.position, relPlayerPos, out hit))
            {
                Debug.Log(hit.collider.gameObject.name.ToString());
                if (hit.collider.gameObject == player)
                {
                    GameManager.Instance.isDetected = true;
                }
                else GameManager.Instance.isDetected = false;
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(pivotPoint.position, relPlayerPos);
    }
}
