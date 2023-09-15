using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    public StickController stickController;

    public float rollSpeed = 45f;
    public float yawSpeed = 30f;
    public float forwardSpeed = 10f;
    public float pitchSpeed = 30f;

    public float yawAngle = 0f;

    private float initialHeight;

    private void Start()
    {
        initialHeight = transform.position.y;
    }

    private void Update()
    {
        UpdateRotation();
        UpdateMovement();
    }

    public void UpdateRotation()
    {
        

        float rollInput = stickController.GetHorizontalStick();
        //float pitchInput = Input.GetAxis("Vertical");
        float pitchInput = 0f;

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
        eulerAngles.x += pitchAngle;
        eulerAngles.y += yawAngle;
        eulerAngles.z += rollAngle;
        transform.rotation = Quaternion.Euler(eulerAngles);


       
    }

    public void UpdateMovement()
    {
        // Calculate forward movement
        float forwardOffset = forwardSpeed * Time.deltaTime;
        transform.Translate(transform.forward * forwardOffset, Space.World);

        // Keep the plane at the initial height
        Vector3 newPosition = transform.position;
        newPosition.y = initialHeight;
        transform.position = newPosition;
    }
}