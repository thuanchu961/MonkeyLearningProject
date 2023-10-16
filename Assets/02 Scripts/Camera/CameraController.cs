using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public void MoveCamera(bool isDown)
    {
        transform.DOMoveY((isDown ? 0 : 10), 1f).SetEase(Ease.InOutSine).OnComplete(()=> { 
            
        });
    }
}
