using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Paramaters of each tower
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    // State of each tower
   [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
      
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}

