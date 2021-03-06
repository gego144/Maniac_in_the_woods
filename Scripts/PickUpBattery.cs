using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpBattery : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Battery;
    public GameObject ExtraCross;
    public GameObject TextBox;
    public GameObject hunter;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Pick up battery.";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(ScenePlayer());
                this.GetComponent<MeshRenderer>().enabled = false;
                if(hunter.activeSelf == false){
                    hunter.SetActive(true);
                }
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Picked up battery.";
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = " ";
        Battery.SetActive(false);

    }
}
