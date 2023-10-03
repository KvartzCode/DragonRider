using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float deathtimer = 5f;

    public int killScore = 100;

    public void StartKillSheep()
    {
        StartCoroutine(KillSheep());
    }

    public IEnumerator KillSheep()
    {
        yield return new WaitForSeconds(deathtimer);
        ScoreManager.Instance.UpdateScore(killScore);
        Destroy(gameObject);
    }
}
