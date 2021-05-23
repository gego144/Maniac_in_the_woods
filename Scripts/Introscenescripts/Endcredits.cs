using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endcredits : MonoBehaviour
{
    public GameObject EscapeMessage;
    public GameObject Thanks;
    public GameObject Credits;
    public AudioSource Finalsong;
    // Start is called before the first frame update
    void Start()
    {
        EscapeMessage.SetActive(true);
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        Finalsong.Play();
        yield return new WaitForSeconds(6);
        EscapeMessage.SetActive(false);
        Thanks.SetActive(true);
        yield return new WaitForSeconds(9);
        Thanks.SetActive(false);
        Credits.SetActive(true);
        yield return new WaitForSeconds(10);
        Finalsong.Pause();
        Application.Quit();


    }
}
