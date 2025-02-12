using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OnAir_State : State_Base
{

    public State_Base _onAir_State;
    public Air_State _jump_State;

    public Fail_State _fallState;
    public JumpAttack_State _jumpAttackState;
    private PlayerController _playerController;

    [SerializeField] string trgParameter;

    float timeToJumpAnimation;


    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        this.SetCore(_playerController);

    }


    public override void Enter()
    {
        _anim.Play("Player_Jump");
        if (_playerController._currentJumpTime <= 0)
        {
            _playerController.ApplyAirLinearDrag();
            _machine.Set(_jump_State);
        }


    }

    public override void Do()
    {

    }



    public override void FixedDo()
    {  
        timeToJumpAnimation= Helpers.Map(_playerController._rb.velocity.y, _playerController._jumpForce-7.5f, -_playerController._jumpForce + 7.5f, 0, 1, true);
         if(timeToJumpAnimation < 0.90)
         {
             _anim.speed = 0;
         }

        
        if(_playerController.isJUmpAttacking)
        {
            _anim.speed =1;
            
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            _machine.Set(_jumpAttackState);

        }
        
     
           

        
           
    

    }
    public override void InExit()
    {   
        _anim.speed = 1;
        _isComplete = true;
    }






}
