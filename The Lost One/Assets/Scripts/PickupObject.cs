using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform spawner;
    public float speed;
    private float shotrtest;
    private Transform current;
    // Start is called before the first frame update
    void Start()
    {
        shotrtest = 10000000f;
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform obj in spawner)
        {
            if (obj != null)
            {
                float dist = Vector3.Distance(obj.transform.position, gameObject.transform.position);
                
                if (dist < shotrtest || shotrtest == 0f)
                {
                    current = obj;
                    shotrtest = dist;
                    float step = speed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, obj.position, step);
                    if (Vector3.Distance(transform.position, obj.position) < 0.001f)
                    {
                        obj.position *= -1.0f;
                    }
                }
                if (current == null)
                {
                    shotrtest = 0f;
                }
            }
        }
    }
}
