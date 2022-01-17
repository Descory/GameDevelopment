using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalBreak : MonoBehaviour
{
    public Text Message;
    private UI data;
    public AudioSource breakSound;
    private EnemyStats enemy;

    private void Awake()
    {
        data = GameObject.FindObjectOfType<UI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Message.text = "Crystal picked up";
            data.UpdateCrystals(1);
            breakSound.Play();
            Destroy(gameObject);

        }
        else if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponent<EnemyStats>();
            enemy.Heal(15);
            breakSound.Play();
            Destroy(gameObject);

        }
    }
}
