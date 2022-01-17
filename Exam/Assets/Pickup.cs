using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float fuelAmmount = 10;
    private Torch torch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            torch = other.gameObject.GetComponent<Torch>();
            torch.fuel += fuelAmmount;
            Destroy(gameObject);
        }
    }
}
