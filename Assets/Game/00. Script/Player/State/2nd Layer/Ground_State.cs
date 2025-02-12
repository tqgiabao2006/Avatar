using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_State : State_Base
{
    public State_Base _ground_State;
    public Idle_State _idle_State;
    public Run_State _run_State;
    private PlayerController _playerController; 

     private void Start()
    { 
         _playerController = GetComponentInParent<PlayerController>(); 
        this.SetCore(_playerController);

    }
    public override void Enter()
    { _machine.Set(_idle_State, true);
    }
    public override void FixedDo()
    {
        if(_playerController.GetInput().x != 0) 
        {
            _machine.Set(_run_State, true) ;
        }
        else
        {
            _machine.Set(_idle_State, true);
        }
    }
}
