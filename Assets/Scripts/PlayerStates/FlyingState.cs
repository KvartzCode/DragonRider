using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
    }

    public override void UpdateState(PlayerStateManager player)
    {
    }

    public override void OnCollision(PlayerStateManager player, Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.ChangePlayerState(player.deadState);
        }
    }
}
