using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class OxygenRelease : MonoBehaviour
{
    public GameObject oxygen;

    private void Update()
    {
        if (GameManager.Instance.isDetectedBySensor == true)
        {
            oxygen.SetActive(true);
        }
        else
            oxygen.SetActive(false);
    }
}
