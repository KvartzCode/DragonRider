using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int score = 100;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RingTracker.Instance.InactivateRing(this.gameObject, score);
            Debug.Log("Ring Collided with player");
        }
    }
}
