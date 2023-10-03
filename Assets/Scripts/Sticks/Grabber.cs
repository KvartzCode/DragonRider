using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grabber : MonoBehaviour
{
    public InputActionReference controllerGrabAction;

    [SerializeField]
    bool controllerCanGrab;

    bool canGrabStick;

    bool tempIsGrabbed;

    public GameObject stickObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerGrabAction.action.IsPressed() && canGrabStick)
        {
            controllerCanGrab = true; 
        }

        if (controllerCanGrab && !controllerGrabAction.action.IsPressed())
        {
            controllerCanGrab = false;
            if(stickObject.GetComponent<VerticalStick>() != null) 
            {
                stickObject.GetComponent<VerticalStick>().isGrabbed = false;
            }

            if(stickObject.GetComponent<HorizontalStick>() != null)
            {
                stickObject.GetComponent<HorizontalStick>().isGrabbed = false;
            }

            if(stickObject.GetComponent<VerticalPositionStick>() != null)
            {
                stickObject.GetComponent<VerticalPositionStick>().isGrabbed = false;
                tempIsGrabbed = stickObject.GetComponent<VerticalPositionStick>().isGrabbed;
            }
        }

        if(controllerCanGrab)
        {
            //Debug.Log("Trying to grab");
            if(stickObject.GetComponent<VerticalStick>() != null ) 
            {
                Debug.Log("Grabbing");
                stickObject.GetComponent<VerticalStick>().UpdateVerticalStick(this.gameObject);
                stickObject.GetComponent<VerticalStick>().isGrabbed = true;
            }

            if(stickObject.GetComponent<HorizontalStick>() != null)
            {
                stickObject.GetComponent<HorizontalStick>().UpdateHorizontalStick(this.gameObject);
                stickObject.GetComponent<HorizontalStick>().isGrabbed = true;
            }

            if(stickObject.GetComponent <VerticalPositionStick>() != null)
            {
                stickObject.GetComponent<VerticalPositionStick>().isGrabbed = true;

                //Debug.Log(tempIsGrabbed + " TempGrabbed");
                //Debug.Log(stickObject.GetComponent<VerticalPositionStick>().isGrabbed + " isGrabbed");

                if (tempIsGrabbed != stickObject.GetComponent<VerticalPositionStick>().isGrabbed)
                {
                    //Debug.Log("Save initial original");
                    stickObject.GetComponent<VerticalPositionStick>().SaveInitialPosX(this.gameObject.transform.localPosition.z);
                }
                tempIsGrabbed = stickObject.GetComponent<VerticalPositionStick>().isGrabbed;
                stickObject.GetComponent<VerticalPositionStick>().UpdateVerticalStickLookAt(this.gameObject);
            }
        }

        //Debug.Log(controllerCanGrab);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Detected something");

        if(other.GetComponent<VerticalStick>() != null)
        {
            //Debug.Log("Detected Vertical");
            stickObject = other.gameObject;
            canGrabStick = true;
            //Debug.Log("Left Grabby");
            return;
        }

        if(other.GetComponent<HorizontalStick>() != null)
        {
            //Debug.Log("Detected Horizontal");
            stickObject = other.gameObject;
            canGrabStick = true;
            //Debug.Log("Right Grabby");
        }

        if (other.GetComponent<VerticalPositionStick>() != null)
        {
            stickObject = other.gameObject;
            canGrabStick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == stickObject)
        {
            canGrabStick = false;
            //Debug.Log("No Grabby");
        }
    }
}
