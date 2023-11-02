using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCamera : MonoBehaviour
{
    protected abstract void MoveCamera();
    protected abstract void ScaleCamera();
}
