using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider colliderMesh;
    [SerializeField] int hitPoints = 1;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDamageSFX;
    AudioSource mySource;


    private void Start()
    {
        mySource = GetComponent<AudioSource>();
    }
    private void OnParticleCollision(GameObject other)
    {
       
        ProcessHit();
        KillEnemy();
    }


    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        mySource.PlayOneShot(enemyHitSFX);

    }
    private void KillEnemy()
    {
        if(hitPoints <= 0)
        {
            var vfx =Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            vfx.Play();

            Destroy(vfx.gameObject, vfx.main.duration);
            AudioSource.PlayClipAtPoint(enemyDamageSFX, Camera.main.transform.position);
            Destroy(this.gameObject);
        }
    }
}
