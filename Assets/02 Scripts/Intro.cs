using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject hook;
    [SerializeField] private float introTime;
    private SoundManager soundManager;
    private void Awake()
    {
        soundManager = SoundManager.Instant;
        GameManager.OnGameStateChanged += IntroGame;
    }
    private void Start()
    {
        //IntroGame();
    }
    public void IntroGame()
    {
        soundManager.PlaySound((int)Constant.SOUND.BlueSea, 0.5f);
        this.transform.DOMoveX(0, introTime).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            StartCoroutine(SwitchScene());
        });
        GameManager.OnGameStateChanged -= IntroGame;
    }
    private IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(0.75f);
        soundManager.PlaySound((int)Constant.SOUND.UnderwaterLoop, 1f);
        Camera.main.transform.DOMoveY(0, 1f).SetEase(Ease.InOutSine).OnComplete(()=> {
            hook.SetActive(true);
            hook.transform.DOMoveY(0, 1f).SetEase(Ease.InOutSine);
        });
        yield return new WaitForSeconds(1f);
        soundManager.PlayGuiding(0f);
    }
}
