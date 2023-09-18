using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField]
    private GameObject[] spawnPoints;

    float closestDistance;
    GameObject closestSpawnPoint;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetClosetsSpawnPoint(Vector3 playerPosition)
    {
        foreach (var spawnPoint in spawnPoints)
        {
            if(closestDistance == 0f)
            {
                closestDistance = spawnPoint.transform.position.magnitude;
                closestSpawnPoint = spawnPoint;
            }

            if(Vector3.Distance(spawnPoint.transform.position, playerPosition) < closestDistance)
            {
                closestDistance = spawnPoint.transform.position.magnitude;
                closestSpawnPoint = spawnPoint;
            }      
        }

        Debug.Log(closestSpawnPoint.name);
        return closestSpawnPoint;
    }
}
