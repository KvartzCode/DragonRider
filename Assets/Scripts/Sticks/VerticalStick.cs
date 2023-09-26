using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VerticalStick : MonoBehaviour
{
    public bool canBeGrabbed;
    public GameObject stickPivot;

    public bool isGrabbed;
    private float verticalRotation;

    private float lerpTime = 0.1f;
    private float elapsedLerpTime;


    private void Start()
    {
        canBeGrabbed = false;
    }

    //private void Update()
    //{
    //    if (!isGrabbed && stickPivot.transform.localEulerAngles.x != 0)
    //    {
    //        elapsedLerpTime = Time.deltaTime;
    //        float percentComplete = elapsedLerpTime / lerpTime;

    //        float lerpAngle = Mathf.LerpAngle(stickPivot.transform.localEulerAngles.x, 0f, percentComplete);

    //        stickPivot.transform.localEulerAngles = new Vector3(lerpAngle, stickPivot.transform.eulerAngles.y, stickPivot.transform.localEulerAngles.z);
    //    }
    //}

    public void UpdateVerticalStick(GameObject touchController)
    {
        float tmpX = touchController.transform.localEulerAngles.x;

        //Set max stick rotation
        if (tmpX >= 0 && tmpX < 180)
        {
            tmpX = Mathf.Clamp(tmpX, 0, 45);

        }

        if (tmpX <= 360 && tmpX >= 180)
        {
            tmpX = Mathf.Clamp(tmpX, 315, 360);
        }

        //Mathf.Clamp(touchController.transform.localEulerAngles.x, -45, 45);
        stickPivot.transform.localEulerAngles = new Vector3(tmpX, stickPivot.transform.localEulerAngles.y, stickPivot.transform.localEulerAngles.z);
        float angle = transform.eulerAngles.x - transform.root.localEulerAngles.x;

        angle = (angle + 360) % 360;

        float offsetAngle = (angle + 90f) % 360;


        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        Debug.LogWarning("vertical angle: " + angleRadians);
        verticalRotation = Mathf.Cos(angleRadians);
        Debug.LogWarning("verticalRotation: " + verticalRotation);
    }

    public float GetVerticalStickAngle()
    {
        return verticalRotation;
    }
}
