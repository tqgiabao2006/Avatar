using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCensor : MonoBehaviour
{
    [Header("Ground Collision Variables")]
    [SerializeField] private float _groundRaycastLength;
    [SerializeField] private Vector3 _groundRaycastOffset;
    [SerializeField] private LayerMask _groundLayer;

    public  bool _onGround;

  private void Update() 
  {
    GroundCheck();
   }

   private void GroundCheck()
   {
     _onGround = Physics2D.Raycast(transform.position + _groundRaycastOffset, Vector2.down, _groundRaycastLength, _groundLayer) ||
      Physics2D.Raycast(transform.position - _groundRaycastOffset, Vector2.down, _groundRaycastLength, _groundLayer);
   }
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.green;

    //     // Ground Check
    //     Gizmos.DrawLine(transform.position + _groundRaycastOffset, transform.position + _groundRaycastOffset + Vector3.down * _groundRaycastLength);
    //  Gizmos.DrawLine(transform.position - _groundRaycastOffset, transform.position - _groundRaycastOffset + Vector3.down * _groundRaycastLength);
    // }
}
