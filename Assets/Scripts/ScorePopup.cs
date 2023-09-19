using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    [SerializeField] float duration = 5;
    [SerializeField] float travelLength = 20;

    [SerializeField] TMP_Text textMesh;

    Transform target;


    void Update()
    {
        if (target)
        {
            transform.forward = transform.position - target.position;
        }
    }

    public void Play(int score, Transform facingTarget)
    {
        target = facingTarget;
        textMesh.text = score.ToString();
        transform.DOMoveY(transform.position.y + travelLength, duration);

        Destroy(gameObject, duration + 1);
    }
}
