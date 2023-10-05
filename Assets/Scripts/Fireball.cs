using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage = 50;
    public float fireballImpulse = 100000;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * fireballImpulse, ForceMode.Impulse);
        
        Destroy(gameObject, 5f);
    }



    public void AddFireballForce(GameObject relativeObject)
    {
        Vector3 tmpVel = relativeObject.GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().AddForce((transform.forward * fireballImpulse) + tmpVel, ForceMode.Impulse);
    }
}
