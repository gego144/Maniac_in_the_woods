using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class KillerAI : MonoBehaviour
{
    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 2;
    int MinDist = 15;
    int timer = 0;

    public AudioSource sound;
    public Animator anim;
    public GameObject TheBox;
    public GameObject Health3;
    public GameObject Health2;
    public GameObject Health1;
    public GameObject TheBlood;
    public Transform killer;
    public NavMeshAgent killer_obj;
    public AudioClip[] footsounds;
    public GameObject user;
    public GameObject walking;
 



    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.speed = 1.2f;
    }

    public void footstep(int _num)
    {
        sound.clip = footsounds[_num];
        sound.Play();
        
    }


    void Update()
    {
        
        float dist = Vector3.Distance(killer.position, Player.position);

        if (dist <= MinDist)
        {
            transform.LookAt(Player);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            

            if (Vector3.Distance(killer.position, Player.position) <= MaxDist)
            {
                if (Health3.activeSelf == true && timer ==0)
                {
                    Health3.SetActive(false);
                    TheBlood.GetComponent<Animation>().Play("HitBlood");
                    timer = 3;
                    StartCoroutine(ScenePlayer());
                }
                else if (Health3.activeSelf == false && Health2.activeSelf == true && timer == 0)
                {
                    Health2.SetActive(false);
                    TheBlood.GetComponent<Animation>().Play("HitBlood");
                    timer = 3;
                    StartCoroutine(ScenePlayer());
                }
                else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == true && timer == 0)
                {
                    Health1.SetActive(false);
                    TheBlood.GetComponent<Animation>().Play("HitBlood");
                    timer = 3;
                    StartCoroutine(ScenePlayer());
                }
                else if (Health3.activeSelf == false && Health2.activeSelf == false && Health1.activeSelf == false && timer == 0)
                {
                    SceneManager.LoadScene(3);
                }

                IEnumerator ScenePlayer()
                {
                    killer.GetComponent<Animation>().Play("Z_Attack");
                    yield return new WaitForSeconds(1);
                    timer = 0;
                   
                }

            }

        }
        else{
            /*
            if(Vector3.Distance(killer.position, RandomNavmeshLocation(15f, user)) == 15.0){

            }
            */
            
             //killer_obj.SetDestination(RandomNavmeshLocation(15f, user));
             if(walking.activeSelf == true){
                    killer_obj.SetDestination(RandomNavmeshLocation(15f, user));
                    killer_obj.destination = RandomNavmeshLocation(15f, user);
                    
                    walking.SetActive(false);

             }
             else if(RandomNavmeshLocation(15f, user) == killer.position){
                 Debug.Log("stopped");
             }
             

        }
        
    }


     public Vector3 RandomNavmeshLocation(float radius, GameObject player) {

         Vector3 randomDirection = new Vector3(Random.Range(player.transform.position.x - 50.0f, player.transform.position.x + 50.0f), 0, Random.Range(player.transform.position.z - 50.0f, player.transform.position.z + 50.0f));
         /*
         NavMeshHit hit;
         Vector3 finalPosition = Vector3.zero;
         if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
             finalPosition = hit.position;            
         }
         */
        
        return randomDirection;
     }
}
