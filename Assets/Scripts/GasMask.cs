using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMask : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.isInvulnerable = true;
            GameManager.Instance.invulnerableUntil = Time.time + GameManager.Instance.invulnerableDuration;
            Destroy(gameObject);
        }
    }
}
