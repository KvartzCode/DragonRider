using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public PlayerStateManager playerStateController;

    public abstract void EnterState(PlayerStateManager player);

    public virtual void UpdateState(PlayerStateManager player)
    {

    }

    public virtual void OnCollision(PlayerStateManager player, Collision collision)
    {
        
    }
}
