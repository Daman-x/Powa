using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script clamps fps to 30 for optimzation
public class FPSManager : MonoBehaviour
{

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }
}
