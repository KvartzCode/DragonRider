using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : PlayerBaseState
{
    public float deathTime = 2f;
    private float timeLeft;

    private GameObject spawnpoint;

    public override void EnterState(PlayerStateManager player)
    {
        spawnpoint = SpawnManager.Instance.GetClosetsSpawnPoint(player.transform.position);
        timeLeft = deathTime;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft < 0)
        {
            SimpleGameStateManager.instance.GameOver();
            //RespawnPlayer(player, spawnpoint);
            //player.ChangePlayerState(player.flyingState);
        }
    }

    public override void OnCollision(PlayerStateManager player, Collision collision)
    {
       
    }

    public void RespawnPlayer(PlayerStateManager player, GameObject spawnpoint)
    {
        player.transform.position = spawnpoint.transform.position;
        player.ChangePlayerState(player.flyingState);
        player.ChangePanelToTransparent();
    }

}
