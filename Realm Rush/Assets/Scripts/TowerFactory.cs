using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    int numberOfTower;
    Queue<Tower> towerQueue = new Queue<Tower>();

    [SerializeField] Transform transformParentTower;

    
  public void AddTower(Waypoint baseWayPoint)
    {

         numberOfTower = towerQueue.Count;

        if(numberOfTower < towerLimit)
        {
            InstantiateNewTower(baseWayPoint);
            numberOfTower++;
        }

        else
        {
            MoveExistingTower(baseWayPoint);
        }


    }

    private void InstantiateNewTower(Waypoint baseWayPoint)
    {
        var newTower = Instantiate(towerPrefab, baseWayPoint.transform.position, Quaternion.identity);
        newTower.transform.parent = transformParentTower;
        baseWayPoint.isPlaceble = false;

        newTower.baseWayPoint = baseWayPoint; // block that tower is standing on current blockS
        baseWayPoint.isPlaceble = false;
     
        towerQueue.Enqueue(newTower);
    }
    private  void MoveExistingTower(Waypoint newBaseWayPoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWayPoint.isPlaceble = true;  // free up the block

        newBaseWayPoint.isPlaceble = false;

        oldTower.baseWayPoint = newBaseWayPoint;

        oldTower.transform.position = newBaseWayPoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }

   
}
