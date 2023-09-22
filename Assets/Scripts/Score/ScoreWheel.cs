using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;


public class ScoreWheel : MonoBehaviour
{
    public float rotateSpeed = 2.5f;
    Tween tween;


    public void UpdateValue(int value)
    {
        if (tween != null)
            tween.Kill();

        if (value <= 0)
            tween = transform.DOLocalRotate(new Vector3(0, 0, 0), rotateSpeed);
        else
            tween = transform.DOLocalRotate(new Vector3(360-(36*value), 0, 0), rotateSpeed);
    }
}
