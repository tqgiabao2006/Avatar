using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail_State : State_Base
{    PlayerController _playerController;


    private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();

    }
    public override void Enter()
    {
        
    }
    public override void Do()
    {
        if(_playerController._rb.velocity.y >=0 && _playerController._onGround)
        {
            _isComplete = true;
            _playerController._isJumping=  false;
        }
        else 
        {
            _playerController._isJumping = true;
        }
    }

    private void Jump()
    {
       
    }
    public override void InInitialise()
    { 
    }
    

    public override void InExit()
    {
       
    }
}
