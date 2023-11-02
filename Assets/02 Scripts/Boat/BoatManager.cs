using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{
    private IMovable boatController;
    private ISetBoatState boatAnimator;

    private SoundManager soundManager;
    private Vector3 startPosition;
    private void Awake()
    {
        boatController = GetComponent<IMovable>();
        boatAnimator = GetComponent<ISetBoatState>();
        soundManager = SoundManager.Instant;
        startPosition = transform.position;
    }
    public void BoatIntro()
    {
        boatController.Move(new Vector3(0, transform.position.y, transform.position.z));
    }
    public void BoatEnding()
    {
        StartCoroutine(Ending());
    }
    private IEnumerator Ending()
    {
        boatAnimator.SetBoatState(Constant.BOAT_STATE.Ending);
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
        boatAnimator.SetBoatState(Constant.BOAT_STATE.Fade);
        yield return new WaitForSeconds(0.25f);
        boatController.Move(startPosition);
    }
}
