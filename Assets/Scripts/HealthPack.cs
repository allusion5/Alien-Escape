using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.Instance.playerHealth != GameManager.Instance.maxHealth)
        {
            GameManager.Instance.playerHealth = GameManager.Instance.maxHealth;
            Destroy(gameObject);
        }
        else return;
    }
}
