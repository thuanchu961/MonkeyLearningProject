using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [Header("Background References")]
    [SerializeField] private GameObject bgA;
    [SerializeField] private GameObject bgB;

    public void ChangeBackground(bool active)
    {
        bgA.SetActive(!active);
        bgB.SetActive(active);
    }
}
