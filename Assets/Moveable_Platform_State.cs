using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable_Platform_State : State_Base
{    PlayerController _playerController; 
     MoveablePlatform _platformScript ;
      GameObject  _platform; 
      bool _isAttached;
     private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();
    }

    public override void FixedDo()
    {   
        if(Input.GetKey(KeyCode.E))
        {_playerController._isMovingPlatform = true;
           _platform = Physics2D.OverlapCircle(_playerController.gameObject.transform.position, 1f, _playerController._moveablePlatformLayer).gameObject;
           if(_platform != null)
              { 
                 if(_platformScript == null) _platformScript = _platform.GetComponent<MoveablePlatform>();
                 _playerController._rb.gravityScale = 0f;
                 _playerController._rb.drag = 0f;
                 _isAttached = true;
                _platformScript.ChangeDirection(_playerController.gameObject, _isAttached);
             }else
             {   _isAttached = false;
                _platformScript.ChangeDirection(_playerController.gameObject, _isAttached);
                _isComplete = true;

             }
        }else
        {   
            _playerController._isMovingPlatform = false;
            _playerController._rb.gravityScale = _playerController._fallMultiplier;
            _isComplete = true;

       
       
     
    }
    
  }
}
