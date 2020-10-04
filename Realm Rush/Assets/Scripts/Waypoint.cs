﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool isExplored = false;
    public bool isPlaceble = true;
    public Waypoint exploredFrom;

    [SerializeField] Tower towerPrefab;
    Vector2Int gridPos;

    const int gridSize = 10;
   

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) ,
            Mathf.RoundToInt(transform.position.z / gridSize) 
        );
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            
        {
            if (isPlaceble)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceble = false;
                print(gameObject.name + "placeble");
            }
            else
            {
                print("Not Placeble");
            }
        }

     
        
    }
}

