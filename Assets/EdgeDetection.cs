using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour
{
    [SerializeField] float _radius;
    [SerializeField] LayerMask _wallCheck;
    PlayerController _playerController;

    private bool _canDetected;
    void Start()
    {
        
            _playerController = this.GetComponentInParent<PlayerController>(); 
        
    }

    void Update()
    {
         _playerController._ledgedDetected = Physics2D.OverlapCircle(this.transform.position,_radius, _wallCheck);
        
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, _radius);    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == _wallCheck)
        {

            _canDetected= false;
        }
    }
     private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == _wallCheck)
        {

            _canDetected= true;
        }
    }

}
