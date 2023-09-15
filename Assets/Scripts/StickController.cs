using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    [SerializeField]
    GameObject horizontalStick;
    [SerializeField]
    GameObject verticalStick;

    public float verticalRotation;
    public float horizontalRotation;

    private void Update()
    {
        GetVerticalStick();
        GetHorizontalStick();
        //Debug.Log("Vertical: " + verticalRotation);
        //Debug.Log("Horizontal: " + horizontalRotation);
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

    public float GetVerticalStick()
    {
        float angle = verticalStick.transform.rotation.eulerAngles.x;

        angle = (angle + 360) % 360;

        float offsetAngle = (angle + 90f) % 360;


        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        return verticalRotation = Mathf.Cos(angleRadians);

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

    public float GetHorizontalStick()
    {
        float angle = horizontalStick.transform.localRotation.eulerAngles.z;

        // Normalize angle
        angle = (angle + 360) % 360;

        //offset angle
        float offsetAngle = (angle + 90f) % 360;

        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        return horizontalRotation = Mathf.Cos(angleRadians);

        //Debug.Log(angle);
        //Debug.Log(offsetAngle);
        //Debug.Log(horizontalRotation);
    }
}
