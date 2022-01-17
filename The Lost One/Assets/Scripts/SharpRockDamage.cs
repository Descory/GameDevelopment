using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpRockDamage : MonoBehaviour
{
    private UI data;
    private EnemyStats enemy;

    private void Awake()
    {
        data = GameObject.FindObjectOfType<UI>();
    }

    //Send damage number to the UI, where it is used, then destroy the object
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            data.Damage(15);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponent<EnemyStats>();
            enemy.Damage(15);
            Destroy(gameObject);
        }
    }
}
