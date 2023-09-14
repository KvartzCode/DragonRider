using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlaneController : MonoBehaviour
{

    public float maxSpeed;
    public float minSpeed;

    public float startSpeed;
    public float currentSpeed;
    public float acceleration = 1f;
    public float deceleration = 1f;

    public float rollSpeed = 1f;
    public float yawSpeed = 1f;
    public float pitchSpeed = 1f;

    public float rollMovement = 1f; // in proportion to scale
    public float rollMovementRotationX = 0.012f;
    public float rollMovementRotationY = 1.5f;
    public float rollMovementPositionY = 0.1f;

    [SerializeField]
    GameObject horizontalStick;
    [SerializeField]
    GameObject verticalStick;

    public float verticalRotation;
    public float horizontalRotation;


    private float lateralPosition = 0f;

    private Vector2 rigthStickControllerInput;
    private Vector2 leftStickControllerInput;

    // Start is called before the first frame update
    void Start()
    {
       

        currentSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //if (leftStickControllerInput != Vector2.zero)
        //{
        //    if (currentSpeed < maxSpeed && leftStickControllerInput.y > 0)
        //    {
        //        currentSpeed += acceleration * leftStickControllerInput.y;
        //    }

        //    if (currentSpeed > minSpeed && leftStickControllerInput.y < 0)
        //    {
        //        currentSpeed += acceleration * leftStickControllerInput.y;
        //    }
        //}

        GetVerticalStick();
        GetHorizontalStick();

        PlaneMovement();
        PlaneRollMovement();

    }

    private void PlaneRollMovement()
    {
        float rollAngle = transform.localEulerAngles.z;

        //Normalize the roll angle to [0, 360) range
        rollAngle = (rollAngle + 360f) % 360f;

        float normalizedRollAngle = rollAngle / 90f; // Normalize to [0, 4) range

        float rollRotationMultiplier = rollMovement * rollMovementRotationY;

        //Target roll rotation
        Quaternion rollRotation = Quaternion.Euler(0f, 0f, normalizedRollAngle * 90f);

        //Apply roll rotation
        Quaternion newRotation = Quaternion.LookRotation(transform.forward, Vector3.up) * rollRotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rollSpeed);

        //Position change proportionally to the roll angle
        float rollDisplacement = normalizedRollAngle * rollRotationMultiplier * Time.deltaTime;

        //Update position
        lateralPosition += rollDisplacement;

        //Ensure the lateral position stays within bounds (-1 to 1)
        lateralPosition = Mathf.Clamp(lateralPosition, -1f, 1f);

        //Calculate the lateral shift in local coordinates
        Vector3 localShift = Vector3.right * lateralPosition * rollMovementPositionY;

        //Apply the lateral shift in world coordinates
        transform.position += localShift;
    }




    public void PlaneMovement()
    {
        transform.Translate(new Vector3(0, 0, currentSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(-verticalRotation * yawSpeed, 0, -horizontalRotation * rollSpeed));
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

    public void GetHorizontalStick()
    {
        float angle = horizontalStick.transform.rotation.eulerAngles.z;

        // Normalize angle
        angle = (angle + 360) % 360;

        //offset angle
        float offsetAngle = (angle + 90f) % 360;

        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        horizontalRotation = Mathf.Cos(angleRadians);

        //Debug.Log(angle);
        //Debug.Log(offsetAngle);
        //Debug.Log(horizontalRotation);
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

    //    Debug.Log(angle);
    //    Debug.Log(verticalRotation);
    //}

    public void GetVerticalStick()
    {
        float angle = verticalStick.transform.rotation.eulerAngles.x;

        angle = (angle + 360) % 360;

        float offsetAngle = (angle + 90f) % 360;

       
        float angleRadians = offsetAngle * Mathf.Deg2Rad;
        verticalRotation = Mathf.Cos(angleRadians);

        Debug.Log(angle);
        Debug.Log(offsetAngle);
        Debug.Log(verticalRotation);
    }
}
