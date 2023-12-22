using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField1; 
    public FixedTouchField _FixedTouchField2;
    public CameraLook _CameraLook;

    public float sensitivity = 1.0f;

    void Update()
    {
        Vector2 touch1Input = _FixedTouchField1.TouchDist;
        Vector2 touch2Input = _FixedTouchField2.TouchDist;
        Vector2 averageInput = (touch1Input + touch2Input) / 2.0f;

        _CameraLook.LockAxis = averageInput * sensitivity;
    }
}
