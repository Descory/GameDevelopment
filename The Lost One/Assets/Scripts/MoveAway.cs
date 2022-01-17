using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAway : MonoBehaviour


{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 1)
        {
            transform.LookAt(Player.transform.position);
            transform.Rotate(0, 180, 0);
            transform.Translate(Vector3.forward);
        }
    }
}
