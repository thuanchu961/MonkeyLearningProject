using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour, IMoveCamera, IScaleCamera
{
    private void Start()
    {
        Scale();
    }
    public void MoveCamera(Vector3 targetPosition)
    {
        IMoveCamera moveCamera = new MovementController(); // => D
        moveCamera.MoveCamera(targetPosition);
    }

    public void Scale()
    {
        IScaleCamera scaleCamera = new ScaleCamera(); // => D
        scaleCamera.Scale();
    }
}
