using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Air_State : State_Base
{
    PlayerController _playerController;
    private   float adjustedJumpForce;
   private void Start()
    {
      _playerController = _core.GetComponent<PlayerController>();
    }

    private float _jumpCount =0;
    
     public override void Enter() 
     {
     }
    public  override  void Do() 
    {  
        if(!_playerController._hasCalledJump) 
        {     
           
             NormalJump(_playerController._horizontalDirection);
             _jumpCount++;
             StartCoroutine(Waiting());
             _isComplete=true;
             _playerController. _extraJumpsValue =  _playerController. _extraJumps;
        }
        if(_playerController._onGround )
        {
            _jumpCount =0;
        }
    }
  
      public override void InExit()
    {
        _isComplete = true;
       
    }
     private void NormalJump(float _input)
    {
    
        Vector2 jumpDirection;
        if(_input >0) 
        {
            jumpDirection = new Vector2(1,1);
        }else if(_input<0)
        {
            jumpDirection = new Vector2(-1,1);
        }else 
        {
            jumpDirection = Vector2.up;
        }
        Jump(jumpDirection);
    }


    private void Jump(Vector2 direction)
    {
        if(_playerController.holdTime >= 0.1f)
        {
          adjustedJumpForce =Mathf.Lerp(_playerController._jumpForce, _playerController._maxJumpForce * 4f,  _playerController.holdTime/_playerController._maxHoldTime);
        }else
        {
            adjustedJumpForce = _playerController._jumpForce;
        }
        
        if (!_playerController._onGround  && !_playerController._onWall && !_playerController._canJump)
        {
            _playerController._extraJumpsValue--;
        }

        _playerController.ApplyAirLinearDrag();
        _playerController._rb.velocity = Vector2.zero;
        _playerController._rb.AddForce(direction.normalized * adjustedJumpForce, ForceMode2D.Impulse); 
        _playerController. _hangTimeCounter = 0f;
        _playerController. _jumpBufferCounter = 0f;
        _playerController._currentJumpTime = _playerController._jumpCoolDown;
         _playerController.holdTime = 0f;

       _playerController._isJumping = true;
    }

    IEnumerator Waiting()
    {
        yield return new  WaitForSeconds(0.05f);
         _playerController._hasCalledJump = true;

    }

 
    public override void InInitialise()
    { 
      
    }
    

    
}
