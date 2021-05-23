using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstExitBuilding : MonoBehaviour
{
    public AudioSource The_Song;
    public GameObject TheBox;
    private void OnTriggerEnter()
    {
        The_Song.Play();
        TheBox.GetComponent<BoxCollider>().enabled = false;

    }
}
