using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerBaseState currentState;

    public DeadState deadState = new DeadState();
    public FlyingState flyingState = new FlyingState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = flyingState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {   
        currentState.UpdateState(this);
    }

    public void ChangePlayerState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);    
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollision(this, collision);
    }
}
