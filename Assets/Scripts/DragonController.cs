using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    public StickController stickController;

    [SerializeField] HorizontalStick horizontalStick;
    [SerializeField] VerticalStick verticalStick;
    [SerializeField] VerticalPositionStick verticalPositionStick;

    public float maxSpeed = 50f;
    public float minSpeed = 10f;
    public float startSpeed = 30;
    public float acceleration = 1f;

    public float rollSpeed = 45f;
    public float yawSpeed = 30f;
    public float forwardSpeed = 10f;
    public float pitchSpeed = 30f;

    public float yawAngle = 0f;

    private float initialHeight;
    private float currentSpeed;

    private Tween rotateTween;


    private void Start()
    {
        initialHeight = transform.position.y;
        currentSpeed = startSpeed;
    }

    private void Update()
    {
        
        UpdateRotation();
        UpdateMovement();
    }

    private void FixedUpdate()
    {
        //UpdateRotation();
        //UpdateMovement();
    }


    public void ResetRotation()
    {
        StopTweenRotation();
        rotateTween = transform.DORotate(Vector3.zero, 3f);

    }

    public void StopTweenRotation()
    {
        if (rotateTween != null)
            rotateTween.Kill();
    }

    public void UpdateRotation()
    {
       
        float rollInput = horizontalStick.GetHorizontalStickAngle();
        //float pitchInput = Input.GetAxis("Vertical");
        float pitchInput = verticalStick.GetVerticalStickAngle();
        //Debug.LogWarning("rollInput: " + rollInput);
        //Debug.LogWarning("pitchInput: " + pitchInput);

        //float pitchInput = 0f;

        //float pitchInput = 0;

        float rollAngle = -rollInput * rollSpeed * Time.deltaTime;

        float pitchAngle = -pitchInput * pitchSpeed * Time.deltaTime;

        float angle = transform.localEulerAngles.z;

        if(angle > 0 && angle < 90f)
        {
            float normalizedAngle = angle / 90f;
            yawAngle = -normalizedAngle * yawSpeed * Time.deltaTime;
            
        }

        if (angle >= 270f && angle < 360f) // Right side up DONE
        {
            float normalizedAngle = (angle - 270) / 90;
            yawAngle = (1 - normalizedAngle) * yawSpeed * Time.deltaTime;
        }

        if(angle >= 90 && angle < 180)
        {
            float normalizedAngle = (angle - 90) / 90f;
            yawAngle = -(1 - normalizedAngle) * yawSpeed * Time.deltaTime;
        }

        if(angle > 180 && angle < 270)
        {
            float normalizedAngle = (angle - 180) / 90;
            yawAngle = normalizedAngle * yawSpeed * Time.deltaTime;
        }

        //Rotate
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.y += yawAngle;

        eulerAngles.x += pitchAngle;
        if (eulerAngles.x > 180 && eulerAngles.x < 315)
        {
            eulerAngles.x = 315;
        }
        if (eulerAngles.x < 180 && eulerAngles.x > 45)
        {
            eulerAngles.x = 45;
        }


        eulerAngles.z += rollAngle;
        if (eulerAngles.z > 180 && eulerAngles.z < 315)
        {
            eulerAngles.z = 315;
        }
        if (eulerAngles.z < 180 && eulerAngles.z > 45)
        {
            eulerAngles.z = 45;
        }

        transform.rotation = Quaternion.Euler(eulerAngles);

        //transform.Rotate(Vector3.right * -pitchInput * pitchSpeed * Time.fixedDeltaTime);

    }

    public void UpdateMovement()
    {
        if (verticalPositionStick.GetVerticalStickPosition() != 0f)
        {
            float stickValue = verticalPositionStick.GetVerticalStickPosition();
            if (currentSpeed < maxSpeed && stickValue > 0)
            {
                currentSpeed += acceleration * stickValue;
            }

            if (currentSpeed > minSpeed && stickValue < 0)
            {
                currentSpeed += acceleration * stickValue;
            }
        }

        // Calculate forward movement
        float forwardOffset = currentSpeed * Time.deltaTime;
        transform.Translate(transform.forward * forwardOffset, Space.World);

        // Keep the plane at the initial height
        //Vector3 newPosition = transform.position;
        //newPosition.y = initialHeight;
        //transform.position = newPosition;
    }
}