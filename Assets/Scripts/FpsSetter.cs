using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsSetter : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
        
    }
}
