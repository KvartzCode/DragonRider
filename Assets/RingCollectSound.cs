using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCollectSound : MonoBehaviour
{
    public AudioClip RingCollect;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        AudioManager.instance.PlayAudio(audioSource, RingCollect);
        }
    }
}
