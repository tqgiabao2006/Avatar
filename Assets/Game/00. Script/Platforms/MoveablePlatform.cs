using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveablePlatform : MonoBehaviour
{
  Vector2 _direction;
Rigidbody2D _rb;
Rigidbody2D _playerBody;
GameObject _playerObject;
bool _isAttached;
[SerializeField] float _speed, _radius;

  private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
      private  void Update() 
    { 

            _rb.velocity = _speed * _direction;

    }

public void ChangeDirection(GameObject playerObject, bool isAttached)
{
  this._playerObject = playerObject;
  this._isAttached = isAttached;
  _rb.gravityScale = 0;
   if(_isAttached)
    { 
          _playerObject.GetComponent<Rigidbody2D>().velocity = _direction * _speed;
    }
  if(Input.GetKeyDown(KeyCode.W))
  {
    _direction = new Vector2(0,1);
  }
  if(Input.GetKeyDown(KeyCode.S))
  {
    _direction = new Vector2(0,-1);
  }
  if(Input.GetKeyDown(KeyCode.D))
  {
    _direction = new Vector2(1,0);
  }   
  if(Input.GetKeyDown(KeyCode.A))
  {
    _direction = new Vector2(-1,0);
  }
  if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
  {
    _direction = new Vector2(1,-1).normalized;
  }
  if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
  {
    _direction = new Vector2(1,1).normalized;
  }
  if(Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
  {
        _direction = new Vector2(-1,1).normalized;

  }
  if(Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
  {
        _direction = new Vector2(-1,-1).normalized;

  }



}
    
}
