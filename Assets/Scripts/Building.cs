using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int destructionPoints = 200;
    public float currentHealth;
    public float maxHealth;
    public float deathTimer = 5f;

    //public MeshRenderer towerRenderer;
    public GameObject smoke;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Fireball>() != null)
        {
            currentHealth -= collision.gameObject.GetComponent<Fireball>().damage;
        }

        if(currentHealth <= 0f)
        {
            StartKillTower();
            //ScoreManager.Instance.UpdateScore(destructionPoints);
            //Destroy(gameObject);
        }
    }

    public void StartKillTower()
    {
        //towerRenderer.enabled = false;
        smoke.active = true;
        StartCoroutine(DestroyTower());
    }

    public IEnumerator DestroyTower()
    {
        yield return new WaitForSeconds(deathTimer);
        Debug.Log("U fukkin Killed me some more");
        ScoreManager.Instance.UpdateScore(destructionPoints);
        Destroy(gameObject);
    }
}
