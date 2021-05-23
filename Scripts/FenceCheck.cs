using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FenceCheck : MonoBehaviour
{
    public GameObject TheBox;

    public GameObject Health3;
    public GameObject Health2;
    public GameObject Health1;
    public GameObject TheBlood;

    private void OnTriggerEnter()
    {
        if (Health3.activeSelf == true)
        {
            Health3.SetActive(false);
            TheBlood.GetComponent<Animation>().Play("HitBlood");
            StartCoroutine(ScenePlayer());
        }
        else if (Health3.activeSelf == false && Health2.activeSelf == true)
        {
            Health2.SetActive(false);
            TheBlood.GetComponent<Animation>().Play("HitBlood");
            StartCoroutine(ScenePlayer());
        }
        else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == true)
        {
            Health1.SetActive(false);
            TheBlood.GetComponent<Animation>().Play("HitBlood");
            StartCoroutine(ScenePlayer());
        }
        else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == false)
        {
            SceneManager.LoadScene(3);
        }

        IEnumerator ScenePlayer()
        {
            TheBox.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(1);
            TheBox.GetComponent<BoxCollider>().enabled = true;

        }
    }
}
