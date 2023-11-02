using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScrollingLayer : MonoBehaviour
{
    protected abstract void Scroll(); // Các class con bắt buộc phải implement và override Scroll
}
