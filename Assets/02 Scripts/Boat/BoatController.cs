using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoatController : MonoBehaviour
{
    private BoatAnimator boatAnimator;
    private Vector3 startPosition;
    private SoundManager soundManager;
    private void Awake()
    {
        boatAnimator = GetComponent<BoatAnimator>();
        soundManager = SoundManager.Instant;
        startPosition = transform.position;
    }
    private void Move(Vector3 position)
    {
        transform.DOMoveX(position.x, 2.5f).SetEase(Ease.InOutSine);
    }
    public void Ending()
    {
        StartCoroutine(BoatEnding());
    }
    private IEnumerator BoatEnding()
    {
        boatAnimator.SetState(BoatAnimator.STATE.Ending);
        yield return new WaitForSeconds(0.25f);
        soundManager.PlaySound((int)Constant.SOUND.Victory, 1f);
        bool isPlaying = true;
        while (isPlaying)
        {
            isPlaying = soundManager.IsSoundPlaying();
            yield return null;
        }
        yield return new WaitForSeconds(0.25f);
        soundManager.PlaySound((int)Constant.SOUND.Hooray, 1f);
        isPlaying = true;
        while (isPlaying)
        {
            isPlaying = soundManager.IsSoundPlaying();
            yield return null;
        }
        yield return new WaitForSeconds(0.25f);
        boatAnimator.SetState(BoatAnimator.STATE.Fade);
        yield return new WaitForSeconds(0.25f);
        Move(startPosition);
    }
}
