using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHurtBox : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("ContactMade");
            GameManager.Instance.playerHealth = 0;
        }
    }
}
