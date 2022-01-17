using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Animator aniController;
    [SerializeField] private Animator aniControllerPl;
    public Item torch;
    public NavMeshAgent myAgent;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            myAgent.isStopped = true;
            aniControllerPl.SetBool("pick", true);
            Inventory.instance.Add(torch);
            obj1.GetComponent<ParticleSystem>().enableEmission = true;
            obj2.GetComponent<ParticleSystem>().enableEmission = true;
            obj3.GetComponent<ParticleSystem>().enableEmission = true;
            obj4.GetComponent<ParticleSystem>().enableEmission = true;
            aniController.SetBool("torchPickUp", true);
            Destroy(gameObject);

        }
    }
}
