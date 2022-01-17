using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float viewRadius = 10f;
    Transform target;
    NavMeshAgent myAgent;
    [SerializeField] private Animator aniController;
    CharacterCombat combat;
    public AudioSource weapon;
    public AudioSource walking;
    private bool Playing;
    public GameObject[] heal;
    EnemyStats me;
    private bool healingItemClose;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        myAgent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        me = this.GetComponent<EnemyStats>();
        Playing = false;
        healingItemClose = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //if((((me.Vitality * 25) + me.BaseHP) / 3 < me.Health))
        //{
        //    healingItemClose = false;
        //}

        //if (((me.Vitality * 25) + me.BaseHP) / 3 >= me.Health)
        //{
        //    foreach (GameObject obj in heal)
        //    {
        //        healingItemClose = false;
        //        if (obj!= null)
        //        {
        //            float distance = Vector3.Distance(obj.gameObject.transform.position, transform.position);
        //            myAgent.stoppingDistance = 0;
        //            if (distance <= viewRadius)
        //            {
        //                healingItemClose = true;
        //                myAgent.SetDestination(obj.gameObject.transform.position);
        //                break;
        //            }
        //        }
        //    }
        //}

        //else if (!healingItemClose)
        //{
            myAgent.stoppingDistance = 2f;
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= viewRadius)
            {
                myAgent.SetDestination(target.position);

                if (distance <= myAgent.stoppingDistance)
                {
                    Stats stat = target.GetComponent<Stats>();
                    if (stat != null)
                    {
                        FaceTarget();
                        combat.Attack(stat, weapon);
                    }
                }
            }
        //}

        if (myAgent.velocity.magnitude < 0.15f)
        {
            aniController.SetBool("moving", false);
            if (Playing)
            {
                walking.Pause();
                Playing = false;
            }
        }
        else
        {
            aniController.SetBool("moving", true);
            if (!Playing)
            {
                walking.Play();
                Playing = true;
            }
        }
    }

    void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
