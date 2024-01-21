using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    public Camera[] cameras;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SwitchCamera(cameras[0]);
        }


        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SwitchCamera(cameras[1]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera(cameras[2]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCamera(cameras[3]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCamera(cameras[4]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchCamera(cameras[5]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SwitchCamera(cameras[6]);
        }
    }

    void SwitchCamera(Camera activeCamera)
    {
        for(int i=0; i < cameras.Length; i++)
        {
            if (!cameras[i].Equals(activeCamera)) {cameras[i].enabled = false; }
            else { cameras[i].enabled = true; }
        }
    }
}
