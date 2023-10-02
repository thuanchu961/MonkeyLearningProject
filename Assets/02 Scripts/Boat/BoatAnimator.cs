using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class BoatAnimator : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private AnimationReferenceAsset Start, Ending, Fade;
    public enum STATE
    {
        Start,
        Ending,
        Fade
    }
    private STATE currentState = STATE.Start;
    private void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        skeletonAnimation.AnimationState.SetAnimation(0, animation, loop);
    }
    public void SetState(STATE state)
    {
        if (currentState == state)
            return;

        switch (state)
        {
            case STATE.Start:
                currentState = STATE.Start;
                SetAnimation(Start, true);
                break;
            case STATE.Ending:
                currentState = STATE.Ending;
                SetAnimation(Ending, false);
                break;
            case STATE.Fade:
                currentState = STATE.Fade;
                SetAnimation(Fade, true);
                break;
        }
    }
}
