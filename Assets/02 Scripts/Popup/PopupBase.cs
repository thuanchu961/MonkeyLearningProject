using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PopupBase : MonoBehaviour
{
    [SerializeField] protected float fadeTime;
    [SerializeField] protected CanvasGroup canvasGroup;
    protected virtual void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
    }
    public virtual void Show()
    {
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeTime);
    }
    public virtual void Hide()
    {
        if (!gameObject.activeSelf) return;
        canvasGroup.DOFade(0, fadeTime).OnComplete(() =>
        {
            SetActive(false);
        });
    }
    public virtual void SetActive(bool value)
    {
        canvasGroup.gameObject.SetActive(value);
    }
}
