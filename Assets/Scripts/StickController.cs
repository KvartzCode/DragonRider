using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField]
    GameObject horizontalStick;
    [SerializeField]
    GameObject verticalStick;
    [SerializeField]
    GameObject dragon;

    public float verticalRotation;
    public float horizontalRotation;

    private void Update()
    {
        //UpdateVerticalStick();
        //UpdateHorizontalStick();
        //Debug.Log("Vertical: " + verticalRotation);
        //Debug.Log("Horizontal: " + horizontalRotation);
    }

    private void FixedUpdate()
    {
        UpdateVerticalStick();
        UpdateHorizontalStick();
    }

    //public void GetVerticalStick()
    //{
    //    float angle = verticalStick.transform.rotation.eulerAngles.x;
    //    if (angle >= 270)
    //    {
    //        angle -= 270f;
    //    }
    //    else
    //    {
    //        angle += 90;
    //    }

    //    float angleRadians = angle * Mathf.Rad2Deg;
    //    verticalRotation = Mathf.Cos(angleRadians);
    //}

    public void UpdateVerticalStick()
    {
        float angle = verticalStick.transform.eulerAngles.x - transform.root.localEulerAngles.x;

        angle = (angle + 360) % 360;

        float offsetAngle = (angle + 90f) % 360;


        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        verticalRotation = Mathf.Cos(angleRadians);

        //Debug.Log(angle);
        //Debug.Log(offsetAngle);
        //Debug.Log(verticalRotation);
    }

    //public void GetHorizontalStick()
    //{
    //    float angle = horizontalStick.transform.rotation.eulerAngles.z;
    //    if (angle >= 270)
    //    {
    //        angle -= 270f;
    //    }
    //    else
    //    {
    //        angle += 90;
    //    }
    //    float angleRadians = angle * Mathf.Deg2Rad;
    //    horizontalRotation = Mathf.Cos(angleRadians);
    //}

    public void UpdateHorizontalStick()
    {
        float angle = horizontalStick.transform.eulerAngles.z - transform.root.transform.localEulerAngles.z;
        //float angle = horizontalStick.transform.eulerAngles.z - dragon.transform.localEulerAngles.z;

        //Normalize angle
        angle = (angle + 360) % 360;

        //offset angle
        float offsetAngle = (angle + 90f) % 360;
        Debug.Log(offsetAngle);

        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        horizontalRotation = Mathf.Cos(angleRadians);

        //Debug.Log(offsetAngle);
        //Debug.Log(horizontalRotation);
    }
    public float GetVerticalStickAngle()
    {
        return verticalRotation;
    }

    public float GetHorizontalStickAngle()
    {
        return horizontalRotation;
    }

}
