using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour, IMovable
{
    public void Move(Vector3 targetPosition)
    {
        transform.DOMoveY(targetPosition.y, 1f).SetEase(Ease.InOutSine).OnComplete(() => {

        });
    }

    public void MoveCamera(bool isDown)
    {
        transform.DOMoveY((isDown ? 0 : 10), 1f).SetEase(Ease.InOutSine).OnComplete(()=> { 
            
        });
    }
}
