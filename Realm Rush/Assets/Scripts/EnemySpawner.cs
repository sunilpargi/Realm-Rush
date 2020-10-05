using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float secondToWait = 4f;
    [SerializeField] GameObject enemy;

    [SerializeField] Transform enemyParentTransform;

    [SerializeField] Text spwanedEnemies;
    int score = 0;
  

    // Update is called once per frame
    void Start()
    {
        spwanedEnemies.text = score.ToString();
        StartCoroutine(enemySpawner());
    }

    IEnumerator enemySpawner()
    {
        while (true) // forever
        {
            AddScore();
            var newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(secondToWait);
        }

    }

    private void AddScore()
    {
        score++;
        spwanedEnemies.text = score.ToString();
    }
}
