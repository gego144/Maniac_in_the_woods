using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public GameObject TheQuit;
    public GameObject TheText;
    public GameObject BlackScreen;
    public AudioSource TheSong;
    public GameObject TextBox;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                TheQuit.SetActive(true);
                TheText.SetActive(true);
                BlackScreen.SetActive(true);
                TheSong.Pause();
                TextBox.GetComponent<Text>().text = " ";


            }

            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                TheQuit.SetActive(false);
                TheText.SetActive(false);
                BlackScreen.SetActive(false);
                TheSong.UnPause();
                
            }

        }
    }
}
