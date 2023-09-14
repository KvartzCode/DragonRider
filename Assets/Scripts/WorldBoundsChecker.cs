using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WorldBoundsChecker : MonoBehaviour
{
    [SerializeField] Image boundsScreen;

    Collider thisCollider;
    Collider otherCollider;
    bool insideWorldBoundsCollider = false;


    void Start()
    {
        if (!thisCollider && !TryGetComponent(out thisCollider))
            Debug.LogError("Can't find collider for WorldsBoundsChecker!");
        if (!boundsScreen)
            boundsScreen = GameObject.Find("BoundsScreen").GetComponent<Image>();
    }

    void Update()
    {
        if (insideWorldBoundsCollider)
        {
            var dist = CalculateDistance();
            var tempCol = boundsScreen.color;
            tempCol.a = Mathf.Lerp(0, 1, dist / 200);
            boundsScreen.color = tempCol;

            if (dist > 220)
                TurnPlayer();
        }
    }


    private void TurnPlayer()
    {
        transform.LookAt(Vector3.zero); //TODO: Change this to something more reliable.
    }

    float CalculateDistance()
    {
        Vector3 otherPosition = otherCollider.gameObject.transform.position;
        Quaternion otherRotation = otherCollider.gameObject.transform.rotation;

        Physics.ComputePenetration(
            thisCollider, transform.position, transform.rotation,
            otherCollider, otherPosition, otherRotation,
            out Vector3 direction, out float distance
        );

        //Vector3 closestPoint = -direction * distance;

        //Debug.Log("Distance " + distance);
        //Debug.Log("ClosestPoint " + closestPoint);

        return distance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("WorldBounds") && otherCollider)
            return;

        otherCollider = other;
        insideWorldBoundsCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != otherCollider)
            return;

        otherCollider = null;
        insideWorldBoundsCollider = false;
    }
}
