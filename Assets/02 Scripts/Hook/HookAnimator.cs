using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class HookAnimator : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation skeletonAnimation;
    [SerializeField] private AnimationReferenceAsset open, close, waiting;
    public enum STATE
    {
        Open,
        Close,
        Waiting
    }
    [SerializeField] private STATE currentState = STATE.Waiting;
    private void Awake()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }
    private void Start()
    {
        SetState(currentState);
    }
    private void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        skeletonAnimation.AnimationState.SetAnimation(0, animation, loop);
    }
    public void SetState(STATE state)
    {
        if (state == currentState)
            return;

        switch (state)
        {
            case STATE.Open:
                currentState = STATE.Open;
                SetAnimation(open, false);
                break;
            case STATE.Close:
                currentState = STATE.Close;
                SetAnimation(close, false);
                break;
            case STATE.Waiting:
                currentState = STATE.Waiting;
                SetAnimation(waiting, true);
                break;
        }
        Debug.Log("change state: " + state);
    }
}
