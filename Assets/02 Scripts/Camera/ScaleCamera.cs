using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCamera : MonoBehaviour, IScaleCamera
{
    public float targetAspectRatio = 16.0f / 9.0f;
    public float orthoSize = 5.0f;

    private Camera mainCamera;

    public void Scale()
    {
        mainCamera = Camera.main;
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;
        float scaleHeight = currentAspectRatio / targetAspectRatio;

        if (scaleHeight > 1f)
        {
            mainCamera.orthographicSize = (1 / scaleHeight) * mainCamera.orthographicSize;
        }

        Debug.Log("Scale camera finished");
    }
}
