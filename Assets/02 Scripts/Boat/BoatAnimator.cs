using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class BoatAnimator : AbstractAnimator, ISetBoatState
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private AnimationReferenceAsset Start, Ending, Fade;
    private Constant.BOAT_STATE currentState = Constant.BOAT_STATE.Start;
    private IAnimationHandler animationHandler;
    private void Awake()
    {
        animationHandler = new AnimationHandler(skeletonAnimation);
    }
    public override void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        animationHandler.SetAnimation(animation, loop);
    }
    public void SetBoatState(Constant.BOAT_STATE newState)
    {
        if (currentState == newState)
            return;

        switch (newState)
        {
            case Constant.BOAT_STATE.Start:
                currentState = Constant.BOAT_STATE.Start;
                SetAnimation(Start, true);
                break;
            case Constant.BOAT_STATE.Ending:
                currentState = Constant.BOAT_STATE.Ending;
                SetAnimation(Ending, false);
                break;
            case Constant.BOAT_STATE.Fade:
                currentState = Constant.BOAT_STATE.Fade;
                SetAnimation(Fade, true);
                break;
        }
    }
}
