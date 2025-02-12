using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_State : State_Base
{    PlayerController _playerController;
    private Vector3 dashStartPosition;
    private Vector3 dashEndPosition;
    [SerializeField] GhostEffect _ghostEffect;
   private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();
    
    }

    public override void Enter()
    {
            
    }

    public override void Do()
    {
        // Perform dash
            if (_playerController.canDash)
            {
                StartCoroutine(Dash(_playerController.dashDirection));
                 _playerController.canDash = false;
                Invoke("ResetDash", _playerController.dashCooldown);
            } 
        
    }
    private IEnumerator Dash(Vector3 direction)
    { 
        
        
        _playerController.isDashing = true;        
        //StartPoint
        dashStartPosition = _playerController.transform.position;

        float elapsedTime = 0;
            _playerController._rb.gravityScale = 0;
            _playerController._rb.drag = 0f;
        while (elapsedTime < _playerController.dashDuration)
        {    
            float step = _playerController.dashDistance * Time.deltaTime / _playerController.dashDuration;
            _playerController.transform.position += direction * step;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _playerController.FallMultiplier();
        _playerController.ApplyGroundLinearDrag();

        //EndPoint
        dashEndPosition = _playerController.transform.position;
        //Spawning
        SpwaningObject();
        _playerController.isDashing = false;

        

    }

    void ResetDash()
    {
         _playerController.canDash = true;
    }

    private void SpwaningObject()
    {    
        
        if( dashEndPosition== Vector3.zero|| dashStartPosition== Vector3.zero) return;
        
         // Calculate the distance between start and end positions
        float distance = Vector3.Distance(dashStartPosition, dashEndPosition);

        // Calculate the direction vector from start to end position
        Vector3 direction = (dashEndPosition - dashStartPosition).normalized;

        // Calculate the positions for the three objects
        Vector3 position1 = dashStartPosition + direction * (distance / 4);
        Vector3 position2 = dashStartPosition + direction * (distance / 2);
        Vector3 position3 = dashStartPosition + direction * (3 * distance / 4);

        //Instantiate ghost
        _ghostEffect.CreateGhost(_playerController, position1);
        _ghostEffect.CreateGhost(_playerController, position2);
        _ghostEffect.CreateGhost(_playerController,position3);

       

    }

    public override void InExit()
    {
         //Reset
        dashEndPosition= Vector3.zero;
        dashStartPosition=Vector3.zero;

    }



}
