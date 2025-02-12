using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
   Rigidbody2D  _rb;
   private float _fallSpeedYDampingChangeThreshold;
    public void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        // _fallSpeedYDampingChangeThreshold = GameManager.Instant._cameraManager
    }

    // Update is called once per frame
    // void Update()
    // {
    //     //if We fa;;omg and passing a certain speed threshold
    //     if(_rb.velocity.y < _fallSpeedYDampingChangeThreshold && !CameraManager.Instant.IsLerpingYDamping && !CameraManager.Instant.LerpedFromPlayerFalling)
    //     {
    //         CameraManager.Instant.LerpYDamping(true);
    //     }
    //     // if we standing till or moving up
    //     if(_rb.velocity.y >= 0.2f && !CameraManager.Instant.IsLerpingYDamping && CameraManager.Instant.LerpedFromPlayerFalling)
    //     {
    //         CameraManager.Instant.LerpedFromPlayerFalling  = true;

    //         CameraManager.Instant.LerpYDamping(false);


    //     }
    // }
}
