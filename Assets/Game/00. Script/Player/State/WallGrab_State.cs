using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGrab_State : State_Base
{
      PlayerController _playerController;

        private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();
    }

     public override void Enter() {}
    public  override  void Do() 
    {
        WallGrab();
     
    }
    void WallGrab()
    {
       _playerController. _rb.gravityScale = 0f;
       _playerController. _rb.velocity = Vector2.zero;

       
        if( !_playerController._wallGrab || _playerController.GetInput() != Vector2.zero) 
        {
          _isComplete = true;
          if(_playerController._onWall)
          {     
                 _playerController._machine._state = _playerController._wallSlide_State;
           }
       }
    }
    public  override void FixedDo() {}
  public override void InExit()
    {
       
    }
}
