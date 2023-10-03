using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Relies on Grabber.cs
/// </summary>
public class HandController : MonoBehaviour
{
    [SerializeField] Transform handParent;
    [SerializeField] MeshFilter handMesh;

    [SerializeField] Mesh normalHand;
    [SerializeField] Mesh grabbingHand;

    private Vector3 originalPosition;
    private Quaternion originalRotation;


    void Start()
    {
        if (!handParent)
            handParent = transform.GetChild(0);
        if (!handMesh)
            handMesh = handParent.GetComponentInChildren<MeshFilter>();
        if (!normalHand)
            normalHand = handMesh.mesh;

        originalPosition = handMesh.transform.localPosition;
        originalRotation = handMesh.transform.localRotation;
    }

    
    public void HandGrabbed(Transform target)
    {
        handMesh.mesh = grabbingHand;
        handParent.transform.SetParent(target);
        handParent.transform.localPosition = Vector3.zero;
        handMesh.transform.localPosition = new Vector3(0.0449f, -0.0056f, -0.0004f);
        handMesh.transform.localRotation = new Quaternion(-0.0905127451f, 0.0703139678f, -0.684613943f, 0.719838321f); //magic numbers, DO NOT TOUCH!
    }

    public void HandReleased()
    {
        handMesh.mesh = normalHand;
        handParent.transform.SetParent(transform);
        handParent.transform.localPosition = Vector3.zero;
        handParent.transform.localRotation = new Quaternion();
        handMesh.transform.localPosition = originalPosition;
        handMesh.transform.localRotation = originalRotation;
    }
}
