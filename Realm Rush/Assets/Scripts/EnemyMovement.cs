﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticlePrefab;
    

    // Use this for initialization
    void Start()
    {

        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }

        selfDestruct();
       
    }

    private void selfDestruct()
    {
        
            var vfx = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
            vfx.Play();

            Destroy(vfx.gameObject, vfx.main.duration);
            Destroy(this.gameObject);
        
    }

}
