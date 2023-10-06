using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Sheep : MonoBehaviour
{
    public float deathtimer = 5f;

    public int killScore = 100;

    public MeshRenderer sheepRenderer;
    public GameObject smoke;
    public void StartKillSheep()
    {
        Debug.Log("U fukkin killed me");
        sheepRenderer.enabled = false;
        smoke.active = true;
        StartCoroutine(KillSheep());
    }

    public IEnumerator KillSheep()
    {
        yield return new WaitForSeconds(deathtimer);
        Debug.Log("U fukkin Killed me some more");
        ScoreManager.Instance.UpdateScore(killScore);
        Destroy(gameObject);
    }
}
