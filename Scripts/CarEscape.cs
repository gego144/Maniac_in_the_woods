using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;


public class CarEscape : MonoBehaviour
{
    public float TheDistance;
    public GameObject ThePlayer;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject GasTank;
    public GameObject Key;
    public GameObject Battery;
    public GameObject TextBox;
    public GameObject BlackScreen;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }
    private void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Enter the car.";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            // if statement for they have everything would play a cutscene
            if (TheDistance <= 2 && GasTank.activeSelf == false && Key.activeSelf == false && Battery.activeSelf == false)
            {

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                ThePlayer.GetComponent<FirstPersonController>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
                BlackScreen.SetActive(true);
                SceneManager.LoadScene(2);

            }
            // if statement for everything but gas
            if (TheDistance <= 2 && GasTank.activeSelf == true && Key.activeSelf == false && Battery.activeSelf == false)
            {

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                TextBox.GetComponent<Text>().text = "You need fuel.";
            }
            // if statement for everything but Key
            if (TheDistance <= 2 && GasTank.activeSelf == false && Key.activeSelf == true && Battery.activeSelf == false)
            {

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                TextBox.GetComponent<Text>().text = "You need the key.";
            }
            // if statement for everything but battery
            if (TheDistance <= 2 && GasTank.activeSelf == false && Key.activeSelf == false && Battery.activeSelf == true)
            {

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                TextBox.GetComponent<Text>().text = "You need the battery.";
            }
            // if statement for only gas
            if (TheDistance <= 2 && GasTank.activeSelf == false && Key.activeSelf == true && Battery.activeSelf == true)
            {

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                TextBox.GetComponent<Text>().text = "You need a key and a battery.";
            }
            // if statement for only key
            if (TheDistance <= 2 && GasTank.activeSelf == true && Key.activeSelf == false && Battery.activeSelf == true)
            {

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                TextBox.GetComponent<Text>().text = "You need fuel and a battery.";
            }
            // if statement for only a battery
            if (TheDistance <= 2 && GasTank.activeSelf == true && Key.activeSelf == true && Battery.activeSelf == false)
            {

                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                TextBox.GetComponent<Text>().text = "You need fuel and a key.";
            }
     

                // if statement for nothing
                if (TheDistance <= 2 && GasTank.activeSelf == true && Key.activeSelf == true && Battery.activeSelf == true)
                {

                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    ExtraCross.SetActive(false);
                    TextBox.GetComponent<Text>().text = "You need fuel, a key, and a battery.";
                }
            }
        }

        void OnMouseExit()
        {
            this.GetComponent<BoxCollider>().enabled = true;
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
            StartCoroutine(ScenePlayer());

        }
        IEnumerator ScenePlayer()
        {
            yield return new WaitForSeconds(2.5f);
            TextBox.GetComponent<Text>().text = " ";

        }
    }



