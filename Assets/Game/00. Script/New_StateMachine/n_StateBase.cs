using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_StateBase : n_IState
{
    protected readonly Core core;
    protected readonly Animator coreAnimator;
    protected const float crossFadeDuration = .1f;

    protected static readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    protected static readonly int NormalAttackHash = Animator.StringToHash("NormalAttackHash");

    protected n_StateBase(Core core, Animator coreAnimator)
    {
        this.core = core;
        this.coreAnimator = coreAnimator;
    }
    public virtual void OnEnter()
    {

    }
    public virtual void OnExit()
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnFixedUpdate()
    {

    }

    
}
