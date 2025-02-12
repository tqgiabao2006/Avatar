using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Run_State : State_Base
{  
     PlayerController _playerController;  
     private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();
    }

    public override void Enter()
    {
        _anim.Play("Player_Run");
    }
    public override void Do()
    {
      

        if(_playerController._rb.velocity.x == 0)
        {
            _isComplete = true;
        }
     
        MoveCharacter();
      


        
    }
  public override void InExit()
    {
       
    }
    private void MoveCharacter()
    {
        _playerController.ApplyGroundLinearDrag();
       _playerController. _rb.AddForce(new Vector2(_playerController._horizontalDirection, 0f) *_playerController. _movementAcceleration);
        if (Mathf.Abs(_playerController._rb.velocity.x) > _playerController._maxMoveSpeed)
            _playerController._rb.velocity = new Vector2(Mathf.Sign(_playerController._rb.velocity.x) * _playerController._maxMoveSpeed,_playerController. _rb.velocity.y);
            _anim.speed = Helpers.Map(_playerController._maxMoveSpeed, 0,1,0, 1.6f, true);
    }

   
}
