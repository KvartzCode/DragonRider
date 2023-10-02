using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RingTracker : MonoBehaviour
{
    
    public static RingTracker Instance;
    [SerializeField] GameObject[] rings;
    public int ringsDone;
    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rings = GameObject.FindGameObjectsWithTag("Ring");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InactivateRing(GameObject ring, int score)
    {
        ScoreManager.Instance.UpdateScore(score);
        Destroy(ring, 1f);
        ringsDone++;
        if (ringsDone == rings.Length)
        {
            // TODO add what happens when all rings are inactivated
            Debug.Log("Finished all ring");
        }
    }
}
