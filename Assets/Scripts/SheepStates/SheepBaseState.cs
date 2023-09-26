using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class SheepBaseState
{
    public virtual void StartState(SheepStateManager sheep)
    {

    }

    public abstract void EnterState(SheepStateManager sheep);


    public virtual void UpdateState(SheepStateManager sheep)
    {

    }

    public virtual void OnCollision(SheepStateManager sheep, Collision collision)
    {

    }

    public virtual void OnTrigger(SheepStateManager sheep, Collider other)
    {

    }

}
