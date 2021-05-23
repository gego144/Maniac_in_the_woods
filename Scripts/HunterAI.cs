using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HunterAI : MonoBehaviour
{
    public GameObject hunterDest;
    NavMeshAgent hunterAgent;
    public GameObject hunterEnemy;
    public static bool isStalking;
    public GameObject Health3;
    public GameObject Health2;
    public GameObject Health1;
    public GameObject TheBlood;
    private float timer;
    public float wanderRadius;
    public float wanderTimer;
    public GameObject GasTank;
    public GameObject Key;
    public GameObject Battery;
    AudioSource audio;
    public GameObject killa;
    private float maxDist = 20.0f;
    private float dist;
    private int hitClock = 0;
    private float attackDist = 2.0f;
    private bool attack;
    private HashSet<int> items = new HashSet<int>();


    void OnEnable () {
        timer = wanderTimer;
    }



    // Start is called before the first frame update
    void Start()
    {
        hunterAgent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();

        isStalking = false;
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(attack == false){
            if(GasTank.activeSelf == false){
                items.Add(1);
            }
            if(Key.activeSelf == false){
                items.Add(2);
            }
            if(Battery.activeSelf == false){
                items.Add(3);
            }
            if(items.Count == 2){
                maxDist = 30.0f;
            }
            if(items.Count == 3){
                maxDist = 40.0f;
            }

            if(isStalking == false){
                dist = Vector3.Distance(hunterEnemy.transform.position, hunterDest.transform.position);
                timer += Time.deltaTime;
                if (timer >= wanderTimer) {
                    hunterEnemy.GetComponent<Animator>().Play("Walking");
                    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                    hunterAgent.SetDestination(newPos);
                    timer = 0;
                }
                if (dist <= maxDist){
                    isStalking = true;
                }
            }

            else{
                hunterEnemy.GetComponent<Animator>().Play("Walking");
                dist = Vector3.Distance(hunterEnemy.transform.position, hunterDest.transform.position);
                hunterAgent.SetDestination(hunterDest.transform.position);
                if (dist > maxDist){
                    isStalking = false;
                }


                if (dist <= attackDist && hitClock == 0)
                {
                    if (Health3.activeSelf == true)
                    {
                        Health3.SetActive(false);
                        TheBlood.GetComponent<Animation>().Play("HitBlood");
                        hitClock = 3;
                        StartCoroutine(ScenePlayer());
                    }
                    else if (Health3.activeSelf == false && Health2.activeSelf == true && hitClock == 0)
                    {
                        Health2.SetActive(false);
                        TheBlood.GetComponent<Animation>().Play("HitBlood");
                        hitClock = 3;
                        StartCoroutine(ScenePlayer());
                    }
                    else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == true && hitClock == 0)
                    {
                        Health1.SetActive(false);
                        TheBlood.GetComponent<Animation>().Play("HitBlood");
                        hitClock = 3;
                        StartCoroutine(ScenePlayer());
                    }
                    else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == false && hitClock == 0)
                    {
                        SceneManager.LoadScene(3);
                    }

                    IEnumerator ScenePlayer()
                    {
                        isStalking = false;
                        hunterEnemy.GetComponent<Animator>().Play("Zombie Attack");
                        hunterAgent.speed = 0.0f;
                        attack = true;
                        yield return new WaitForSeconds(2);
                        hunterAgent.speed = 3.1f;
                        hitClock = 0;
                        isStalking = true;
                        attack = false;
                    }
                }
            }
        }
    }


    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}
