using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class VerticalPositionStick : MonoBehaviour
{
    public bool canBeGrabbed;
    public GameObject stickPivot;
    public GameObject stickBase;

    public GameObject controller; //for testing can be removed

    public float verticalRotation;
    public bool isGrabbed;

    private float lerpTime = 0.1f;
    private float elapsedLerpTime;

    private float tmpX; //for test, can be local

    private float currentControlPosition;
    public float initialControlPosition;

    [SerializeField] private float maxOffsetZ = 1;


    private void Start()
    {
        canBeGrabbed = false;
    }

    private void Update()
    {
        //if (controller != null)
        //{
        //    Vector3 tmpTargetPos = new Vector3(stickBase.transform.position.x, controller.transform.position.y, controller.transform.position.z);
        //    Debug.DrawLine(stickBase.transform.position, tmpTargetPos, Color.red);

        //    Vector3 tmpStickRotation = stickBase.transform.up;
        //    Vector3 tmpDirection = tmpTargetPos - stickBase.transform.position;
        //    //Quaternion tmpRotation = Quaternion.LookRotation(tmpStickRotation);
        //    //stickPivot.transform.localRotation(new Vector3(touchController.transform.position.x, tmpStickRotation.y, tmpStickRotation.z));


        //    tmpX = Vector3.SignedAngle(tmpStickRotation, tmpDirection, stickPivot.transform.right);
        //    Debug.Log(tmpX);
        //}

        if (!isGrabbed && stickPivot.transform.localEulerAngles.x != 0)
        {
            elapsedLerpTime = Time.deltaTime;
            float percentComplete = elapsedLerpTime / lerpTime;

            float lerpAngle = Mathf.LerpAngle(stickPivot.transform.localEulerAngles.x, 0f, percentComplete);

            stickPivot.transform.localEulerAngles = new Vector3(lerpAngle, stickPivot.transform.localEulerAngles.y, stickPivot.transform.localEulerAngles.z);
        }

    }

    public void SaveInitialPosX(float initPosition)
    {
        //Debug.Log("save initial");
        initialControlPosition = initPosition;

    }

    public void UpdateVerticalStickLookAt(GameObject touchController)
    {
        currentControlPosition = touchController.transform.localPosition.z - (initialControlPosition);

        currentControlPosition = Mathf.Clamp(currentControlPosition, -maxOffsetZ, maxOffsetZ);
        float lerpFactor = currentControlPosition / maxOffsetZ;
        lerpFactor += 1;
        lerpFactor *= 0.5f;
        //Debug.Log(lerpFactor + " LerpFactor");
        float cntrlRotX = Mathf.Lerp(-45, 45, lerpFactor);
        //Debug.Log(cntrlRotX); //Awesome solution


        //Vector3 tmpTargetPos = new Vector3(stickBase.transform.position.x, touchController.transform.position.y, touchController.transform.position.z);
        //Vector3 tmpStickRotation = stickBase.transform.up;
        //Vector3 tmpDirection = (tmpTargetPos - stickBase.transform.position).normalized;
     
        //tmpX = Vector3.SignedAngle(tmpStickRotation, tmpDirection, stickBase.transform.right);

        //if (touchController.transform.position.z < stickBase.transform.position.z)
        //    tmpX *= -1;

        //if (tmpX < 0f)
        //{
        //    tmpX = 360 - tmpX * -1;
        //}

   
        //if (tmpX >= 0 && tmpX < 180)
        //{
        //    tmpX = Mathf.Clamp(tmpX, 0, 45);

        //}

        //if (tmpX <= 360 && tmpX >= 180)
        //{
        //    tmpX = Mathf.Clamp(tmpX, 315, 360);
        //}

        stickPivot.transform.localEulerAngles = new Vector3(cntrlRotX, stickPivot.transform.localEulerAngles.y, stickPivot.transform.localEulerAngles.z);
        float angle = transform.eulerAngles.x - transform.root.localEulerAngles.x;

        angle = (angle + 360) % 360;

        float offsetAngle = (angle + 90f) % 360;


        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        verticalRotation = (Mathf.Cos(angleRadians)) * -1;
        Debug.Log(verticalRotation);
    }

    public float GetVerticalStickPosition()
    {
        
        return verticalRotation;
    }
}