using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiosensorLineOfSight : MonoBehaviour
{

    public GameObject player;
    public Transform pivotPoint;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pivotPoint = GetComponentInParent<Transform>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            Vector3 relPlayerPos = player.transform.position - pivotPoint.position;
            RaycastHit hit;

            if (Physics.Raycast(pivotPoint.position, relPlayerPos, out hit))
            {
                if (hit.collider.gameObject == player)
                {
                    Debug.Log("I see you");
                }
            }
        }
    }
}
