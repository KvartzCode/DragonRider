using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerBaseState currentState;
    public AudioClip music;

    public DeadState deadState = new DeadState();
    public FlyingState flyingState = new FlyingState();

    public GameObject blackScreenObject;

    // Start is called before the first frame update
    void Start()
    {
        currentState = flyingState;

        if (music != null)
        {
            AudioManager.instance.PlayMusicTrack(music);
        }

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
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Mountains"))
        {
            Debug.Log("Collided");
            ChangePanelToBlack();
            ChangePlayerState(deadState);
        }
    }

    public void ChangePanelToBlack()
    {
        Color tmpColor = blackScreenObject.GetComponent<Image>().color;
        tmpColor.a = 1f;
        blackScreenObject.GetComponent<Image>().color = tmpColor;
    }

    public void ChangePanelToTransparent()
    {
        Color tmpColor = blackScreenObject.GetComponent<Image>().color;
        tmpColor.a = 0f;
        blackScreenObject.GetComponent<Image>().color = tmpColor;
    }
}
