using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : IAnimationHandler
{
    private SkeletonAnimation skeletonAnimation;
    public AnimationHandler(SkeletonAnimation skeletonAnimation)
    {
        this.skeletonAnimation = skeletonAnimation;
    }
    public void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        skeletonAnimation.AnimationState.SetAnimation(0, animation, loop);
    }
}
