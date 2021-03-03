using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biosensor : MonoBehaviour
{
    public Transform origin;
    public Vector3 detectionArea;

    // Start is called before the first frame update

    float maxDistance = 300f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (GameManager.Instance.gameActive == true)
        {
            //Physics.BoxCast(origin.position, detectionArea, origin.forward);
            //raycast check here
            return;
        }
    }
    void OnDrawGizmos()
    {
        RaycastHit hit;

        bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit, transform.rotation, maxDistance);
            if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
        }
    }
}
