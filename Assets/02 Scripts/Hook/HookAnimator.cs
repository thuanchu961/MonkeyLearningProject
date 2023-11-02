using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class HookAnimator : AbstractAnimator, ISetHookState
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private AnimationReferenceAsset open, close, waiting;
    private IAnimationHandler animationHandler;

    [SerializeField] private Constant.HOOK_STATE currentState = Constant.HOOK_STATE.Waiting;
    private void Awake()
    {
        animationHandler = new AnimationHandler(skeletonAnimation);
    }
    private void Start()
    {
        SetHookState(currentState);
    }
    public override void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        animationHandler.SetAnimation(animation, loop);
    }
    public void SetHookState(Constant.HOOK_STATE newState)
    {
        if (newState == currentState)
            return;

        switch (newState)
        {
            case Constant.HOOK_STATE.Open:
                currentState = Constant.HOOK_STATE.Open;
                SetAnimation(open, false);
                break;
            case Constant.HOOK_STATE.Close:
                currentState = Constant.HOOK_STATE.Close;
                SetAnimation(close, false);
                break;
            case Constant.HOOK_STATE.Waiting:
                currentState = Constant.HOOK_STATE.Waiting;
                SetAnimation(waiting, true);
                break;
        }
        Debug.Log("change state: " + newState);
    }
}
