using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage = 50;
    public float fireballImpulse = 100000;
    

    public float fireballDestroyTime = 5f;
    private float timer;

    private AudioSource audioSource;
    public AudioClip fireballWoosh;

    public bool canPlaySound = false;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * fireballImpulse, ForceMode.Impulse);

        if(canPlaySound)
        {
            AudioManager.instance.PlayAudio(audioSource, fireballWoosh);
        }

        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireballDestroyTime) 
        {
            Destroy(gameObject);
        }
    }



    public void AddFireballForce(GameObject relativeObject)
    {
        Vector3 tmpVel = relativeObject.GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().AddForce((transform.forward * fireballImpulse) + tmpVel, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }



}
