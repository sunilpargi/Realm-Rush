using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrese = 1;

    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamageSFX;



    private void Start()
    {
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        health  -= healthDecrese;
        healthText.text = health.ToString();
    }
}
