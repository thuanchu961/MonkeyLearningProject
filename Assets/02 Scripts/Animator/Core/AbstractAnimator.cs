using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public abstract class AbstractAnimator : MonoBehaviour, IAnimationHandler
{
    public abstract void SetAnimation(AnimationReferenceAsset animation, bool loop);
}
