using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public Vector3 middle;
    public Vector3 area;
    public GameObject damager;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        SpawnSpikes();
        obj1.GetComponent<ParticleSystem>().enableEmission = false;
        obj2.GetComponent<ParticleSystem>().enableEmission = false;
        obj3.GetComponent<ParticleSystem>().enableEmission = false;
        obj4.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawns spikes in a given area
    public void SpawnSpikes()
    {
        for (int i = 0; i < 70; i++)
        {
            Vector3 position = middle + new Vector3(Random.Range(-area.x / 2, area.x / 2), Random.Range(-area.y / 2, area.y / 2), Random.Range(-area.z / 2, area.z / 2));

            Instantiate(damager, position, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawCube(middle, area);
    }
}
