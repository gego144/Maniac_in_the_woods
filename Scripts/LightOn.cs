using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    public GameObject TheFlashLight;
    public Light flashlight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && flashlight.enabled == false && TheFlashLight.activeSelf == true)
        {
            flashlight.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && flashlight.enabled == true && TheFlashLight.activeSelf == true)
        {
            flashlight.enabled = false;
        }

    }
 
}
