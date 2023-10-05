using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baaaaa : MonoBehaviour
{
    public AudioClip Bהההההה;
    public AudioSource audioSource;
    private int Cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown = Random.Range(1, 200);

        if (Cooldown == 1)
        {
            AudioManager.instance.PlaySound(audioSource, Bהההההה, false);
        }

    }
}
