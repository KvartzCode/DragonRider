using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class PanicState : SheepBaseState
{
    public float panicTime = 5f;
    public float changeDirectionTimer = 0.5f;
    public float currentDirectionTime;
    public float currentTime;
    private int currentWayPointIndex;
    private int nextWaypointIndex;
    private GameObject waypointObject;
    private List<GameObject> waypoints;
    private float normalSpeed;
    private float panicSpeed = 3;
   


    public override void EnterState(SheepStateManager sheep)
    {
        panicTime = Random.Range(5f, 10f);
        currentTime = panicTime;
        waypoints = sheep.sheepWaypoints;
        normalSpeed = sheep.sheepAgent.speed;
        sheep.sheepAgent.speed = panicSpeed;

        SetNewPanicDirection(sheep.sheepAgent);

        Debug.Log("Panic");
    }

    public override void UpdateState(SheepStateManager sheep)
    {
        currentTime -= Time.deltaTime;
        currentDirectionTime -= Time.deltaTime;

        if(currentTime < 0 )
        {
            sheep.sheepAgent.speed = normalSpeed;
            sheep.ChangeSheepState(sheep.chillState);
            
        }

        if (currentDirectionTime < 0f)
        {
            SetNewPanicDirection(sheep.sheepAgent);
        }
    }


    private void SetNewPanicDirection(NavMeshAgent sheepAgent)
    {
        currentDirectionTime = Random.Range(0f, changeDirectionTimer);
        currentWayPointIndex = Random.Range(0, waypoints.Count - 1);
        waypointObject = waypoints[currentWayPointIndex];
        sheepAgent.SetDestination(waypointObject.transform.position);
    }
}
