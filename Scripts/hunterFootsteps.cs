using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hunterFootsteps : MonoBehaviour

{
    public AudioClip[] footsounds;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void footstep(){
        AudioClip clip = footsounds[UnityEngine.Random.Range(0, footsounds.Length)];
        sound.PlayOneShot(clip, 0.7F);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
