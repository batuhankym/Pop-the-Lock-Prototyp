using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraTransitions : MonoBehaviour
{
   [SerializeField] private Camera cam;
    
    
    
    
    private void Awake()
    {
        cam = Camera.main;
        if (cam != null) cam.transform.DOMoveX(0, 1).SetEase(Ease.InOutSine);
    }
    
}
