using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
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

    public float rollMovement = 15f;
    public float rollMovementRotationX = 0.012f;
    public float rollMovementRotationY = 1.5f;
    public float rollMovementPositionY = 0.1f;

    private Vector2 rigthStickControllerInput;
    private Vector2 leftStickControllerInput;

    [SerializeField]
    private InputActionReference rotationAction;
    [SerializeField]
    private InputActionReference movementAction;


    // Start is called before the first frame update
    void Start()
    {
        rotationAction.action.performed += GetRightStickControllerInput;
        movementAction.action.performed += GetLeftStickControllerInput;
        

        currentSpeed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(leftStickControllerInput != Vector2.zero)
        {
            if (currentSpeed < maxSpeed && leftStickControllerInput.y > 0)
            {
                currentSpeed += acceleration * leftStickControllerInput.y;
            }

            if(currentSpeed > minSpeed && leftStickControllerInput.y < 0) 
            {
                currentSpeed += acceleration * leftStickControllerInput.y;
            }
        }
        DragonMovement();
        DragonRollMovement();

    }

    private void DragonRollMovement()
    {
        float angle = transform.localEulerAngles.z;

        float yRotationMultiplier = rollMovement * rollMovementRotationY;
        float xRotationMultiplier = rollMovement * rollMovementRotationX;
        float yPositionMultiplier = rollMovement * rollMovementPositionY;

        if (angle >= 270f && angle < 360f) // Right side up DONE
        {
            float normalizedAngle = (angle - 270f) / 90;
            float invert = 1f - normalizedAngle;

            transform.Rotate(Vector3.up * (yRotationMultiplier * invert) * Time.deltaTime);
            transform.Rotate(Vector3.right * (xRotationMultiplier * -invert) * pitchSpeed * Time.deltaTime);
            transform.Translate(transform.up * (yPositionMultiplier * invert) * Time.deltaTime);
        }
        else if (angle > 0f && angle < 90f) // Left side up DONE
        {
            float normalizedAngle = angle / 90f;

            transform.Rotate(-Vector3.up * (yRotationMultiplier * normalizedAngle) * Time.deltaTime);
            transform.Rotate(Vector3.right * (xRotationMultiplier * -normalizedAngle) * pitchSpeed * Time.deltaTime);
            transform.Translate(transform.up * (yPositionMultiplier * normalizedAngle) * Time.deltaTime);
        }
        else if (angle >= 90f && angle < 180f) // Right side down
        {
            float normalizedAngle = (angle - 90f) / 90f;
            float invert = 1f - normalizedAngle;

            transform.Translate(transform.up * (yRotationMultiplier * invert) * Time.deltaTime);
            transform.Rotate(Vector3.right * (xRotationMultiplier * -invert) * pitchSpeed * Time.deltaTime);
        }
        else if (angle >= 180f && angle < 270f) // Left side down DONE
        {
            float normalizedAngle = (angle - 180f) / 90f;

            transform.Translate(transform.up * (yRotationMultiplier * normalizedAngle) * Time.deltaTime);
            transform.Rotate(Vector3.right * (xRotationMultiplier * -normalizedAngle) * pitchSpeed * Time.deltaTime);
        }
    }

    public void DragonMovement()
    {
        transform.Translate(new Vector3(0, 0, currentSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(rigthStickControllerInput.y * yawSpeed, 0, -rigthStickControllerInput.x * rollSpeed));
    }

    public void GetRightStickControllerInput(InputAction.CallbackContext value)
    {
        rigthStickControllerInput = value.ReadValue<Vector2>();
    }

    public void GetLeftStickControllerInput(InputAction.CallbackContext value) 
    {
        leftStickControllerInput = value.ReadValue<Vector2>();
    }
}
