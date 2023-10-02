using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusicTrack(AudioClip musicTrack)
    {
        audioSource.clip = musicTrack;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySound(AudioSource objectAudioSource, AudioClip audio, bool loop)
    {
        objectAudioSource.clip = audio;
        objectAudioSource.loop = loop;
        objectAudioSource.Play();
    }

    public void PlayAudio(AudioSource objectAudioSource, AudioClip clip)
    {
        objectAudioSource.PlayOneShot(clip);
    }
}
