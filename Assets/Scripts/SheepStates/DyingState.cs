using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build;
using UnityEngine;

public class DyingState : SheepBaseState
{
    public override void EnterState(SheepStateManager sheep)
    {
        float timer = sheep.timeToSuffer;
        int score = sheep.GetComponent<Sheep>().killScore;
       
    }
}
