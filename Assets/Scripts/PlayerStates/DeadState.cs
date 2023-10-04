using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        GameObject spawnpoint = SpawnManager.Instance.GetClosetsSpawnPoint(player.transform.position);

        player.transform.position = spawnpoint.transform.position;
        player.ChangePlayerState(player.flyingState);
    }

    public override void UpdateState(PlayerStateManager player)
    {
    }

    public override void OnCollision(PlayerStateManager player, Collision collision)
    {
       
    }

}
