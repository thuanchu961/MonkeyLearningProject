using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    [SerializeField] private float introTime;

    private void Start()
    {
        this.transform.DOMoveX(0, introTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            StartCoroutine(SwitchScene());
        });
    }
    private IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(0.75f);
        Camera.main.transform.DOMoveY(0, 1f).SetEase(Ease.InOutSine);
    }
}
