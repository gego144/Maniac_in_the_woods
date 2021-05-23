using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceChecker : MonoBehaviour
{
    void OnCollisionEnter (Collision collision)
    {
        if (collision.collider.tag == "Fence")
        {
            Debug.Log("Working bruv");
        }
    }
}
