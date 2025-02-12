using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForPlayer : MonoBehaviour
{

    PlayerController _playerController;
     void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        
    }
    void Update()
    {
        this.transform.position = _playerController.transform.position;
        
    }
    void CallTurn()
    {
        LeanTween.rotateY(gameObject, RotationYValue(), 0.5f ).setEaseInOutSine();

    }
    private float RotationYValue()
    {
      if(_playerController._facingRight) return 0f;
      else return 180f;
    }
}
