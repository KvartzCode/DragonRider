using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baaaaa : MonoBehaviour
{
    public AudioClip Bהההההה;
    public AudioSource audioSource;
    private int Cooldown;
    [SerializeField] float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;
        Cooldown = Random.Range(1, 300);
        if (Timer <= 10)
        {
            if (Cooldown == 1)
            {
                AudioManager.instance.PlaySound(audioSource, Bהההההה, false);
                Timer = 0;
            }

        }

    }
}
