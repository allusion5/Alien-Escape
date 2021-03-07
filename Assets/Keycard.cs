using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.hasKeyCard = true;
            //powerup sound?
            //UI Icon for kard cey
            Destroy(gameObject);
        }
    }
}
