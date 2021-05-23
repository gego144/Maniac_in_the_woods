using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Beartrap : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject ColliderThing;
    public GameObject Health3;
    public GameObject Health2;
    public GameObject Health1;
    public GameObject TheBlood;

    private void OnTriggerEnter()
    {
        if (Health3.activeSelf == true)
        {
            TheBlood.GetComponent<Animation>().Play("HitBlood");
            Health3.SetActive(false);
        }
        else if (Health3.activeSelf == false && Health2.activeSelf == true){
            TheBlood.GetComponent<Animation>().Play("HitBlood");
            Health2.SetActive(false);
        }
        else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == true)
        {
            TheBlood.GetComponent<Animation>().Play("HitBlood");
            Health1.SetActive(false);
        }
        else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == false)
        {
            TheBlood.GetComponent<Animation>().Play("HitBlood");
            SceneManager.LoadScene(3);
        }
        ThePlayer.GetComponent<CharacterController>().enabled = false;
        StartCoroutine(ScenePlayer());

    }
    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "You have been caught by a beartrap.";
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<Text>().text = "Five.";
        yield return new WaitForSeconds(1);
        TextBox.GetComponent<Text>().text = "Four.";
        yield return new WaitForSeconds(1);
        TextBox.GetComponent<Text>().text = "Three.";
        yield return new WaitForSeconds(1);
        TextBox.GetComponent<Text>().text = "Two.";
        yield return new WaitForSeconds(1);
        TextBox.GetComponent<Text>().text = "One.";
        yield return new WaitForSeconds(1);
        TextBox.GetComponent<Text>().text = " ";
        ColliderThing.GetComponent<CapsuleCollider>().enabled = false;
        ThePlayer.GetComponent<CharacterController>().enabled = true;
        

    }
}
