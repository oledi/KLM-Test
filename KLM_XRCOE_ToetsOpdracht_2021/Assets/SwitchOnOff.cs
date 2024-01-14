using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{
    private Light light;

    void Awake()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (light.isActiveAndEnabled)
            {
                light.enabled = false;
            }
            else
            {
                light.enabled = true;
            }


        }

    }
}
