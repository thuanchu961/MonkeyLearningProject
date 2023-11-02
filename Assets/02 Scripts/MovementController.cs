using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementController : IMovable, IMoveCamera
{
    public void Move(Vector3 targetPosition)
    {
        throw new System.NotImplementedException();
    }
    public void MoveCamera(Vector3 targetPosition)
    {
        Camera.main.transform.DOMoveY(targetPosition.y, 1f).SetEase(Ease.InOutSine).OnComplete(() => {

        });
    }
}
