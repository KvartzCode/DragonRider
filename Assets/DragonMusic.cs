using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMusic : MonoBehaviour
{
    public AudioClip dragonMusic;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound(audioSource, dragonMusic, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
