using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator aniController;
    public LayerMask ableToClick;
    private NavMeshAgent myAgent;
    public UI data;
    public float speedModifier;
    public AudioSource footSteps;
    public Interactable focus;
    public Stats stats;
    private bool Playing;
    CharacterCombat combat;
    public AudioSource weapon;

    public void stopDistance(float stoppingdist)
    {
        myAgent.stoppingDistance = stoppingdist;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        speedModifier = 1;
        combat = GetComponent<CharacterCombat>();
    }

    /* Upon pressong left mosue button, the if statement becomes true
     * Using rays, the mouse position on the screen will be used
     * together with NavMesh and destination for the player will be made
     */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(myRay, out hitInfo, 100))
                {
                    Interactable interact = hitInfo.collider.GetComponent<Interactable>();
                    if (interact == null)
                    {
                        if (Physics.Raycast(myRay, out hitInfo, 100, ableToClick))
                        {


                            if (stats.Health >= 50)
                                myAgent.speed = stats.Health / 10 * speedModifier;
                            else
                                myAgent.speed = 4 * speedModifier;
                            myAgent.SetDestination(hitInfo.point);
                            myAgent.stoppingDistance = 0.15f;
                            myAgent.isStopped = false;
                            RemoveFocus();
                        }

                    }
                    if (interact != null)
                    {
                        SetFocus(interact);

                        if (stats.Health >= 50)
                            myAgent.speed = stats.Health / 10 * speedModifier;
                        else
                            myAgent.speed = 4 * speedModifier;
                        myAgent.SetDestination(focus.transform.position);
                        myAgent.isStopped = false;
                    }
                }
            }
        }

        if(focus != null)
        {
            myAgent.stoppingDistance = 1.5f;
            if (myAgent.remainingDistance <= myAgent.stoppingDistance)
            {
                myAgent.isStopped = false;
                Vector3 dir = (focus.transform.position - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);

                Stats stat = focus.GetComponent<Stats>();
                if (stat != null)
                {
                    
                    combat.Attack(stat,weapon);
                }
            }
            else
            {
                if (stats.Health >= 50)
                    myAgent.speed = stats.Health / 10 * speedModifier;
                else
                    myAgent.speed = 4 * speedModifier;
                Vector3 dir = (focus.transform.position - transform.position).normalized;
                Quaternion rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
                myAgent.SetDestination(focus.transform.position);
            }
        }
        if (myAgent.velocity.magnitude < 0.15f)
        {
            aniController.SetBool("moving", false);
            if (Playing)
            {
                footSteps.Pause();
                Playing = false;
            }
        }
        else
        {
            aniController.SetBool("moving", true);
            if (!Playing)
            {
                aniController.SetBool("pick", false);
                footSteps.Play();
                Playing = true;
            }
        }
        if (myAgent.destination == myAgent.transform.position)
        {
            myAgent.isStopped = false;
        }
        
        
    }
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null){
                focus.OnNotFocused();
            }
            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnNotFocused();
        }
        focus = null;
    }

}
