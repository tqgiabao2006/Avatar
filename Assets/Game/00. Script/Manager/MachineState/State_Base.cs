using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State_Base : MonoBehaviour
{
     public bool _isComplete {get; protected set; }
    protected float _startTime;
    public float _time => Time.time - _startTime; 

    protected Animator _anim => _core._anim;
    protected Rigidbody2D _rb => _core._rb;
    protected Core _core;

    public MachineState _machine;
    public MachineState _parentState;

    public State_Base _state => _machine._state;



    public virtual void Enter() {}
    public virtual void Do() {}
    public virtual void FixedDo() {}
     public void Exit() 
     {
        // _playerController.ReturnIdleState();
        InExit();


     }

     public virtual void InExit()
     {

     }

   //   public void SetUp( Animator animator, PlayerController playerController)
   //   {
   //      _animator = animator;
   //      _playerController = playerController;
   //   }

   public void SetCore(Core core)
   {
      _machine = new MachineState();
      _core = core;
      
   }

   protected void Set(State_Base newState, bool forceSet = false)
   {
      _machine.Set(newState, forceSet);
   }

     public void Initialise(MachineState parent)
     {   _parentState = parent;
         _isComplete = false;
         _startTime = Time.time;
         InInitialise();
     }

     public void DoBranch()
     {
        Do();
        _state?.DoBranch();
     }
     public void FixedDoBranch()
     {
        FixedDo();
        _state?.FixedDoBranch();
     }

     public virtual void InInitialise()
     {

     }

     


}
