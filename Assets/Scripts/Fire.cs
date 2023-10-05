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

    private GameObject fireballObject;

    GameObject fireball;

    public float fireCooldown = 1f;
    public int continuousShotsFired;
    public float timerBetweencontinuous = 0.1f;
    public int maxBurst = 5;

    private float cooldownTimer = 0;
    private float singleshotTimer = 0;
    public bool hasFired;
    public bool hasFiredOnce;



    private void Update()
    {
        if (hasFired)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                hasFired = false;
                continuousShotsFired = 0;
            }
        }

        if(hasFiredOnce)
        {
            singleshotTimer -= Time.deltaTime;
            if(singleshotTimer <= 0)
            {
                hasFiredOnce = false;
            }
        }

        if (!hasFired && Input.GetMouseButtonDown(0) || !hasFired && fireInput.action.IsPressed())
        {
            if (!hasFiredOnce)
            {
                Shoot();
                Debug.Log("Shooting");
            }
        }
    }

    public void Shoot()
    {
        continuousShotsFired++;

        if (fireballPrefab)
        {
            fireballObject = Instantiate(fireballPrefab, fireballSpawnPoint.transform.position, fireballSpawnPoint.transform.rotation);
            fireballObject.GetComponent<Fireball>().AddFireballForce(this.gameObject);
        }
        singleshotTimer = timerBetweencontinuous;

        if (continuousShotsFired >= maxBurst)
        {
            hasFired = true;
            cooldownTimer = fireCooldown;
        }
    }
}
