using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text fuel;
    public Text time;
    public Torch torch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuel.text = "Fuel: " + torch.fuel;
        time.text = "Time: " + (torch.fuel /torch.burningRate);
    }
}
