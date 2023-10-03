using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int destructionPoints = 200;
    public float currentHealth;
    public float maxHealth;

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
            ScoreManager.Instance.UpdateScore(destructionPoints);
            Destroy(gameObject);
        }
    }
}
