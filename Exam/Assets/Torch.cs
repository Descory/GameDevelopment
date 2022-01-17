using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public float fuel;
    public float burningRate = 1;
    public GameObject light;
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (fuel > 0)
            {
                fuel = fuel - (Time.deltaTime * burningRate);
            }
            else
            {
                fuel = 0;
                light.SetActive(false);
                active = false;
            }
            if (Input.GetKeyDown("z"))
            {
                light.SetActive(false);
                active = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("z"))
            {
                light.SetActive(true);
                active = true;
            }
        }
    }
}
