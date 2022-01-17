using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetItem : MonoBehaviour
{
    [SerializeField] private Animator PlayerAnimator;
    public Item item;
    public GameObject pickUp;
    public NavMeshAgent myAgent;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            myAgent.isStopped = true;
            PlayerAnimator.SetBool("pick", true);
            
            bool isPicked = Inventory.instance.Add(item);
            if (isPicked)
            {
                Destroy(gameObject);
            }
        }
    }

}
