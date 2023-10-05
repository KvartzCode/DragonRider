using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSound1 : MonoBehaviour
{
    public AudioClip DragonFlapping;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlaySound(audioSource, DragonFlapping, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
