using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWall_State : State_Base
{
    public State_Base _onWall_State;
    public WallJump_State _wallJump_State;
    public WallGrab_State _wallGrab_State;
    public WallSlide_State _wallSlide_State;
    
    // public Neutrual _neutralJump_State;

    public WallRun_State _wallRun_State;
    
    // public Neutrual _neutrualJump_State;
    private PlayerController _playerController; 
     private void Start()
    { 
         _playerController = GetComponentInParent<PlayerController>(); 
        this.SetCore(_playerController);

    }
    public override void FixedDo()
    {
      if(_playerController._canJump)
        {
            _machine.Set(_wallJump_State, true);
            _playerController._isJumping = true;
        }else if(!_playerController._isJumping && !_playerController._onMoveablePlatform)  
        {    if(_playerController._wallRun)
            {  
                _machine.Set(_wallRun_State, true);
            }    
            else if(_playerController._wallGrab && !_playerController._onMoveablePlatform)
            {
                _machine.Set(_wallGrab_State, true);
                        
                    
            }
            else
            {
                 _machine.Set(_wallSlide_State, true);

                        
            }
           
        } 
      
    }
}

