using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Neutrual : State_Base
{
    PlayerController _playerController;

  private float _jumpCount = 0;
  
  private float _timeStart = 0;
  private float _timeCount;
    private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();
    }
     public override void Enter() 
     {
       _jumpCount=0;
     }
    public  override  void Do() 
    {
      _timeCount = Time.time;

      if(_jumpCount == 0)
      {     
         StartCoroutine(NeutralWallJump());
      
            _timeStart = Time.time;
           _jumpCount++;
          
      }
      if(_playerController._onGround  || _timeCount - _timeStart >= 0.5f )
      {
        _jumpCount =0;
      }

      


    }
    public  override void FixedDo() {}
     public override void InExit()
    {
       
    }

      IEnumerator NeutralWallJump()
    {
        // Vector2 jumpDirection = _playerController._onRightWall ? Vector2.right: Vector2.left;
        Jump(Vector2.up);        
        yield return new WaitForSeconds(_playerController._wallJumpXVelocityHaltDelay);
        _playerController._rb.velocity = new Vector2(0f,_playerController. _rb.velocity.y);
    }
     private void Jump(Vector2 direction)
    {        _playerController._rb.velocity = Vector2.zero;

       _playerController. _rb.AddForce(direction.normalized * 1.8f * _playerController._jumpForce, ForceMode2D.Impulse);
      //   _playerController. _hangTimeCounter = 0f;
      //  _playerController. _jumpBufferCounter = 0f;
       _playerController._isJumping = true;
       StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
      yield return new WaitForSeconds(0.5f);
      _isComplete = true;
    }
}
