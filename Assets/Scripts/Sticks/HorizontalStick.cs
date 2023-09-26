using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class HorizontalStick : MonoBehaviour
{
    public bool canBeGrabbed;
    public GameObject stickPivot;

    public float horizontalRotation;
    public bool isGrabbed;

    private float currentZAngle;
    private float lerpTime = 0.1f;
    private float elapsedLerpTime;


    private void Start()
    {
        canBeGrabbed = false;
    }

    private void Update()
    {
        if (!isGrabbed && stickPivot.transform.localEulerAngles.z != 0)
        {
            elapsedLerpTime = Time.deltaTime;
            float percentComplete = elapsedLerpTime / lerpTime;
            
            float lerpAngle = Mathf.LerpAngle(stickPivot.transform.localEulerAngles.z, 0f, percentComplete);

            stickPivot.transform.localEulerAngles = new Vector3(stickPivot.transform.eulerAngles.x, stickPivot.transform.localEulerAngles.y, lerpAngle);
        }
    }

    public void UpdateHorizontalStick(GameObject touchController)
    {

        float tmpZ = touchController.transform.localEulerAngles.y;

        //Set max stick rotation
        if (tmpZ >= 0 && tmpZ < 180)
        {
            tmpZ = Mathf.Clamp(tmpZ, 0, 45);
            
        }

        if (tmpZ <= 360 && tmpZ >= 180)
        {
            tmpZ = Mathf.Clamp(tmpZ, 315, 360);
        }

        Mathf.Clamp(touchController.transform.localEulerAngles.z, -45, 45);
        stickPivot.transform.localEulerAngles = new Vector3(stickPivot.transform.eulerAngles.x, stickPivot.transform.eulerAngles.y, -tmpZ);
        float angle = transform.eulerAngles.z - transform.root.localEulerAngles.z;
        //float angle = transform.eulerAngles.z - transform.root.transform.localEulerAngles.z;
        //float angle = horizontalStick.transform.eulerAngles.z - dragon.transform.localEulerAngles.z;

        //Normalize angle
        angle = (angle + 360) % 360;

        currentZAngle = tmpZ;
        //offset angle
        float offsetAngle = (angle + 90f) % 360;
        //Debug.Log(offsetAngle);

        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        horizontalRotation = Mathf.Cos(angleRadians);
    }

    public float GetHorizontalStickAngle()
    {
        return horizontalRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Detected Something");
        if (other.gameObject.CompareTag("Grabber"))
        {
            //Debug.Log("Detected Grabber");
            canBeGrabbed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Grabber"))
        {
            canBeGrabbed = false;
        }
    }
}
