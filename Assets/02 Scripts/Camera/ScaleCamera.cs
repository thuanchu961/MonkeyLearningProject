using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCamera : MonoBehaviour
{
    public float targetAspectRatio = 16.0f / 9.0f;
    public float orthoSize = 5.0f;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        //float screenAspect = (float)Screen.width / Screen.height;
        //float targetAspect = (float)1920 / 1080;
        //if (screenAspect > targetAspect)
        //{
        //    camera.orthographicSize = (targetAspect / screenAspect) * camera.orthographicSize;
        //}
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;
        float scaleHeight = currentAspectRatio / targetAspectRatio;

        if (scaleHeight > 1f)
        {
            mainCamera.orthographicSize = (1/scaleHeight) * mainCamera.orthographicSize;
        }
    }
}
