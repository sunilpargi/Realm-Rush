using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float secondToWait = 4f;
    [SerializeField] GameObject enemy;

    [SerializeField] Transform enemyParentTransform;
  

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(enemySpawner());
    }

    IEnumerator enemySpawner()
    {
        while (true) // forever
        {
            var newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(secondToWait);
        }
     
    }
}
