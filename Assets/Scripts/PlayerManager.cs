using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public enum PlayerState { Dead, Flying };

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerGameobject;

    public static PlayerManager Instance { get; private set; }

    public PlayerState currentState = PlayerState.Flying;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerGameobject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void ChangePlayerState(PlayerState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case PlayerState.Dead:
                RespawnPlayer();
                break;
                
                case PlayerState.Flying:
                break;
        }
    }

    public void RespawnPlayer()
    {
        currentState = PlayerState.Flying;

        GameObject spawnpoint = SpawnManager.Instance.GetClosetsSpawnPoint(playerGameobject.transform.position);
        playerGameobject.transform.position = spawnpoint.transform.position;
    }

    public void PermakillPlater()
    {

    }

    
}
