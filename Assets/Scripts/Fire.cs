using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    [SerializeField]
    GameObject fireballPrefab;
    [SerializeField]
    GameObject fireballSpawnPoint;
    [SerializeField]
    InputActionReference fireInput;

    GameObject fireball;

    public float fireCooldown = 5;
    
    private float cooldownTimer = 0;
    private bool hasFired;


    private void Update()
    {
        if (hasFired)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                hasFired = false;
            }
        }

        if (!hasFired && Input.GetMouseButtonDown(0) || fireInput.action.IsPressed())
        {
            Shoot();
            Debug.Log("Shooting");
        }
    }

    public void Shoot()
    {
        if (fireballPrefab)
        {
            Instantiate(fireballPrefab, fireballSpawnPoint.transform.position, fireballSpawnPoint.transform.rotation);
        }
        cooldownTimer = fireCooldown;
        hasFired = true;
    }
}
