﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public void Start(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
        Application.Quit();
    }
}
