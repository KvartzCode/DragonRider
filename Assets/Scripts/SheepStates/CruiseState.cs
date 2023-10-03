using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiseState : SheepBaseState
{
    GameObject waypointGameobject;

    float cruiseTime;
    float currentTimer;
    bool isNotEmpty;
    bool hasChangedDirection;
    int currentWaypointIndex;
    int newWaypointIndex;
    

    public override void EnterState(SheepStateManager sheep)
    {
        if(sheep.sheepWaypoints != null)
        {
            currentWaypointIndex = Random.Range(0, sheep.sheepWaypoints.Count - 1);
            waypointGameobject = sheep.sheepWaypoints[currentWaypointIndex];
            sheep.sheepAgent.SetDestination(waypointGameobject.transform.position);
            isNotEmpty = true;
            cruiseTime = Random.Range(5f, 20f);
            currentTimer = cruiseTime;
            Debug.Log("Cruising");
        }
    }

    public override void UpdateState(SheepStateManager sheep)
    {
        currentTimer -= Time.deltaTime;
        if( currentTimer < 0f )
        {
            sheep.sheepAgent.ResetPath();
            sheep.ChangeSheepState(sheep.chillState);
        }

        if(isNotEmpty)
        {
            float destinationDistance = Vector3.Distance(sheep.transform.position, waypointGameobject.transform.position);

            if (destinationDistance < 1f && !hasChangedDirection)
            {
                sheep.ChangeSheepState(sheep.chillState);
                //do
                //{
                //    newWaypointIndex = Random.Range(0, sheep.sheepWaypoints.Count - 1);
                //}
                //while (currentWaypointIndex == newWaypointIndex);

                //currentWaypointIndex = newWaypointIndex;
                //waypointGameobject = sheep.sheepWaypoints[currentWaypointIndex];
                //sheep.sheepAgent.SetDestination(waypointGameobject.transform.position);
                //hasChangedDirection = true;
            }
            else if(destinationDistance > 2f && hasChangedDirection)
            {
                hasChangedDirection = false;
            }
        }
    }

    public override void OnTrigger(SheepStateManager sheep, Collider other)
    {
        if(other.gameObject.GetComponent<Fireball>() != null)
        {
            sheep.timesPissedOff++;
            if(sheep.timesPissedOff >= sheep.pissedOffTolerance)
            {
                sheep.ChangeSheepState(sheep.ramboState);
                return;
            }
            sheep.ChangeSheepState(sheep.panicState);
        }
    }
}
