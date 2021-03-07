using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePod : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.Instance.hasKeyCard == true)
        {
            GameManager.Instance.WinMenuUp();
        }
    }
}
