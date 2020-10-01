using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider colliderMesh;
    [SerializeField] int hitPoints = 10;
    void Start()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        print("I am hit");
        ProcessHit();
        KillEnemy();
    }


    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print(hitPoints);
    }
    private void KillEnemy()
    {
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
