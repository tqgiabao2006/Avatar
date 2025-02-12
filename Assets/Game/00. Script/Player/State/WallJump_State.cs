using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump_State : State_Base
{    PlayerController _playerController;
   private void Start()
    {
      _playerController = _core.GetComponent<PlayerController>();
    }

    private float _jumpCount =0;
    
     public override void Enter() 
     {
        if(_playerController._onWall)
        {
            _jumpCount =0;
        }
     }
    public  override  void Do() 
    {     
        if(_jumpCount == 0)
        {      WallJump();
             _jumpCount++;
             _isComplete=true;
        }
        if(_playerController._onGround )
        {
            _jumpCount =0;
        }
    }
    public  override void FixedDo() {}
      public override void InExit()
    {
       
    }
     private void WallJump()
    { _playerController._rb.velocity = Vector3.zero;
       _playerController._rb.gravityScale = 0f;
        Vector2 jumpDirection = _playerController._onRightWall ? Vector2.left : Vector2.right;
        Jump(Vector2.up + jumpDirection);
    }
    private void Jump(Vector2 direction)
    {
        
        if (!_playerController._onGround  && !_playerController._onWall && !_playerController._canJump)
        {
            _playerController._extraJumpsValue--;
        }
        _playerController.ApplyAirLinearDrag();
        _playerController._rb.velocity = Vector2.zero;
        _playerController._rb.AddForce((direction + Vector2.up)  * _playerController._jumpForce, ForceMode2D.Impulse);
        _playerController. _hangTimeCounter = 0f;
       _playerController. _jumpBufferCounter = 0f;
       _playerController._isJumping = true;
    }
}
