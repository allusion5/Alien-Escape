using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class OxygenRelease : MonoBehaviour
{
    //particle effect variable

    // Start is called before the first frame update
    private void Update()
    {
        if (GameManager.Instance.isDetected == true)
        {
            //play particle
            return;
        }
        else return;
           //don't play particle
    }
}
