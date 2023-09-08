using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float rotationZ = 40f;
    public float rotationX = 40f;
    private float rotX;
    private float rotY;
    private float rotZ;


    [SerializeField]
    private InputActionReference verticalRotationAction;
    float lastInput = 0.0f;
    


    float continousRotation;

    // Start is called before the first frame update
    void Start()
    {
        verticalRotationAction.action.performed += OnVerticalRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rotation = new Vector3(0, lastInput, 0);
        //transform.Rotate(rotation);
    }

    public void OnVerticalRotation(InputAction.CallbackContext value)
    {
        //Vector2 input = value.ReadValue<Vector2>();
        //    lastInput = input.x;
        //    transform.Rotate(input.y * rotationX, input.x, -input.x * rotationZ, Space.Self);
        //    Debug.Log(input.ToString());

        Vector2 input = value.ReadValue<Vector2>();
        lastInput = input.x;

        rotZ = input.x * -rotationZ;
        rotX = input.y * rotationX;
        rotY += input.x * 2;
        rotX += input.y * 2;


        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(rotX, rotY, rotZ), Time.deltaTime);
        Debug.Log(input.ToString());
        //if (input != Vector2.zero)
        //{
        //}


    }
}
