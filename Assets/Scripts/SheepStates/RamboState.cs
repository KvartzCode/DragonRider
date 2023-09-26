using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamboState : SheepBaseState
{
    public float ramboTimer = 5f;

    public override void EnterState(SheepStateManager sheep)
    {
        Debug.Log("Mothafukkin Rambo");
    }

    public override void UpdateState(SheepStateManager sheep)
    {
        ramboTimer -= Time.deltaTime;

        if(ramboTimer < 0f) 
        {
            sheep.ChangeSheepState(sheep.chillState);
        }
    }
}
