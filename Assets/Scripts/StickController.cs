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
        //GetVerticalStick();
        //GetHorizontalStick();
        //Debug.Log("Vertical: " + verticalRotation);
        //Debug.Log("Horizontal: " + horizontalRotation);
    }

    public void GetVerticalStick()
    {
        float angle = verticalStick.transform.rotation.eulerAngles.x;
        if (angle >= 270)
        {
            angle -= 270f;
        }
        else
        {
            angle += 90;
        }
        
        float angleRadians = angle * Mathf.Rad2Deg;
        verticalRotation = Mathf.Cos(angleRadians);
    }

    public void GetHorizontalStick()
    {
        float angle = horizontalStick.transform.rotation.eulerAngles.z;
        if (angle >= 270)
        {
            angle -= 270f;
        }
        else
        {
            angle += 90;
        }
        float angleRadians = angle * Mathf.Deg2Rad;
        horizontalRotation = Mathf.Cos(angleRadians);
    }
}
