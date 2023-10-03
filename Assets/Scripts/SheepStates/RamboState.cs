using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamboState : SheepBaseState
{
    public float ramboTimer = 5f;
    private float timeLeft;

    public override void EnterState(SheepStateManager sheep)
    {
        ramboTimer = Random.Range(5f, 10f);
        Debug.Log("Mothafukkin Rambo");
        timeLeft = ramboTimer;
    }

    public override void UpdateState(SheepStateManager sheep)
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft < 0f) 
        {
            sheep.ChangeSheepState(sheep.chillState);
        }
    }
}
