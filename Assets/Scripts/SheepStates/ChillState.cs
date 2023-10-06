using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChillState : SheepBaseState
{
    float chillTime;
    float currentTimer;


    public override void StartState(SheepStateManager sheep)
    {
        //Debug.Log("StartState");
        chillTime = Random.Range(0f, 15);
        currentTimer = chillTime;
    }

    public override void EnterState(SheepStateManager sheep)
    {
        chillTime = Random.Range(30.0f, 60.0f);
        currentTimer = chillTime;
        //Debug.Log("Chillin");
    }

    public override void UpdateState(SheepStateManager sheep)
    {
        currentTimer -= Time.deltaTime;

        if(currentTimer < 0.0f) 
        {
            sheep.ChangeSheepState(sheep.cruiseState);
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

    public override void OnCollision(SheepStateManager sheep, Collision collision)
    {
        if(collision.gameObject.GetComponent<Fireball>() != null)
        {
            sheep.ChangeSheepState(sheep.dyingState);
        }
    }

}
