using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun_State : State_Base
{       PlayerController _playerController;
 private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();

    }
     public override void Enter() 
     {

      _anim.Play("Player_WallClimb");

      
     }
    public  override  void Do()
     {
         

        WallRun();
  
     
     }
    public  override void FixedDo() {}
  public override void InExit()
    {
       
    }

      void WallRun()
    {     _playerController._rb.gravityScale= 0;
       _playerController._currentWallRunCD -= Time.deltaTime;
      if(_playerController._currentWallRunCD >0) return;
        _playerController._rb.velocity = new Vector2(_playerController._rb.velocity.x, _playerController._verticalDirection * _playerController._maxMoveSpeed * _playerController._wallRunModifier);
        _playerController._currentWallRunCD = _playerController._wallRunCD;
    }

    #region Neutral Wall Jump
//  private float _jumpCount =0;
    
//     IEnumerator StartJump()
//     {
//       NeutralJump();
//             _playerController._rb.gravityScale = 0f;

//       yield return new WaitForSeconds(0.5f);
//       _isComplete = true;
//       _playerController._onTopWall = false;

//     }
//     private void NeutralJump()
//     {
//       if(!_playerController._hasCalledJump) 
//         {     
           
//              NormalJump(_playerController._horizontalDirection);
//              _jumpCount++;
//              StartCoroutine(Waiting());

//              _isComplete=true;
//              _playerController. _extraJumpsValue =  _playerController. _extraJumps;
//         }
//         if(_playerController._onWall)
//         {
//             _jumpCount =0;
//         }
//     }
    
//      private void NormalJump(float _input)
//     {
//        Vector2 direction = _playerController._onRightWall ? new Vector2(1,1) : new Vector2(-1,1);
       
//         Jump(direction);
//     }
//     private void Jump(Vector2 direction)
//     {
        
//         if (!_playerController._onGround  && !_playerController._onWall && !_playerController._canJump)
//         {
//             _playerController._extraJumpsValue--;
//         }

//         _playerController._rb.velocity = Vector2.zero;
//         _playerController._rb.AddForce(direction* _playerController._jumpForce * 1.8f, ForceMode2D.Impulse); 
//         _playerController. _hangTimeCounter = 0f;
//         _playerController. _jumpBufferCounter = 0f;
//         _playerController._currentJumpTime = _playerController._jumpCoolDown;
//        _playerController._isJumping = true;

       

//     }

//     IEnumerator Waiting()
//     {
//         yield return new  WaitForSeconds(0.05f);
//                                         _playerController._hasCalledJump = true;

//     }

      
    #endregion
   

    
}
