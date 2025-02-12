using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide_State : State_Base
{    
    PlayerController _playerController;


    private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();
    }
     public override void Enter() {}
    public  override  void Do() 
    {
       WallSlide();
       if(_playerController._onGround) _isComplete = true;
        
    }
      void WallSlide()
    {
        _playerController._rb.velocity = new Vector2(_playerController._rb.velocity.x, -_playerController._maxMoveSpeed * _playerController._wallSlideModifier);
    }

    public  override void FixedDo() {}
      public override void InExit()
    {
       
    }
}

