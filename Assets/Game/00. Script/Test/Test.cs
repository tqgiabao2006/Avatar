using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{  
  
//   public float rotationSpeed = 10f; 
// public float _speed;
    Rigidbody2D _rb;
 
#region Light Effect
//      private void Start()
//     {
//         _rb = GetComponent<Rigidbody2D>();
//         _rb.gravityScale = 0;
//     }

//     void Update()
//     {
//         // Get the current rotation
//         Vector3 currentRotation = transform.rotation.eulerAngles;
//          {if (Input.GetKey(KeyCode.W) )
//          {
//         currentRotation.z += rotationSpeed * Time.deltaTime;

//          }
//              if (Input.GetKey(KeyCode.S))
//         {
//             currentRotation.z -= rotationSpeed * Time.deltaTime;
//         }
        

//          }
//         transform.rotation = Quaternion.Euler(currentRotation);
//     }

//     private  void FixedUpdate() 
//     {
//         _rb.velocity = _speed * this.transform.right;
//     }
#endregion

#region MoveableObject

// Vector2 _direction;
// GameObject _playerObject;

//   private void Start()
//     {
//         _rb = GetComponent<Rigidbody2D>();
//         _rb.gravityScale = 0;
//     }
//       private  void FixedUpdate() 
//     {
//         _rb.velocity = _speed * _direction;
//         if(_playerObject != null)
//         {
//           Rigidbody2D _playerRb = _playerObject.GetComponent<Rigidbody2D>();
//           _playerRb.velocity = _speed * _direction; 
//         }
//     }
// private void Update()
// {      ChangeDirection();
// }


// private void ChangeDirection()
// {
//   if(Input.GetKeyDown(KeyCode.W))
//   {
//     _direction = new Vector2(0,1);
//   }
//   if(Input.GetKeyDown(KeyCode.S))
//   {
//     _direction = new Vector2(0,-1);
//   }
//   if(Input.GetKeyDown(KeyCode.D))
//   {
//     _direction = new Vector2(1,0);
//   }   
//   if(Input.GetKeyDown(KeyCode.A))
//   {
//     _direction = new Vector2(-1,0);
//   }
//   if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
//   {
//     _direction = new Vector2(1,-1).normalized;
//   }
//   if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
//   {
//     _direction = new Vector2(1,1).normalized;
//   }
//   if(Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
//   {
//         _direction = new Vector2(-1,1).normalized;

//   }
//   if(Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
//   {
//         _direction = new Vector2(-1,-1).normalized;

//   }



// }
    
#endregion  
#region Ori Dash


  
#endregion

// #region SUperJump

//  public float jumpForce = 10f;
//  public float  _maxJumpForce = 20f;
//     public float maxHoldTime = 2f;
//     private float holdTime = 0f;
//     private bool isJumping = false;

//     void Start()
//     {
//         _rb = GetComponent<Rigidbody2D>();  
//     }
//     void Update()
//     {
//         // Check if the spacebar is being held down
//         if (Input.GetKey(KeyCode.Space))
//         {
//             holdTime += Time.deltaTime;
//             if (holdTime > maxHoldTime)
//             {
//                 holdTime = maxHoldTime;
//             }
//             isJumping = true;
//         }

//         // Check if the spacebar is released
//         if (Input.GetKeyUp(KeyCode.Space))
//         {
//             if (isJumping)
//             {
//                 FullJump();
//                 holdTime = 0f;
//                 isJumping = false;
//             }
//         }

//         // Normal jump without holding spacebar
//         if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
//         {
//             Jump(jumpForce);
//         }
//     }

//     void FullJump()
//     {
//         float adjustedJumpForce = Mathf.Lerp(jumpForce, _maxJumpForce, holdTime/maxHoldTime);
//         //  jumpForce * (1 + (holdTime / maxHoldTime));
//             _rb.AddForce(Vector3.up * adjustedJumpForce, ForceMode2D.Impulse);
//             StartCoroutine(AddBounce());
//     }

//     void Jump(float force)
//     {
//         _rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
//     }
    
//     private IEnumerator AddBounce()
//     {
//         yield return new WaitForSeconds(0.1f);
//         _rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
//     }
// #endregion


// [SerializeField] GameObject ghostPrefab;


//   private void Update()
//   {
//     if(Input.GetKey(KeyCode.Alpha1))
//     {
//           GameObject g = ObjectPooling.Instant.GetObj(ghostPrefab.gameObject);
//       g.transform.position = this.transform.position;


//     }
    
//   }
#region Bash Abilities
 

    // [Header("Bash")]
    // [SerializeField] private float Raduis;
    // [SerializeField] GameObject BashAbleObj;
    // private bool NearToBashAbleObj;
    // private bool IsChosingDir;
    // private bool IsBashing;
    // [SerializeField] private float BashPower;
    // [SerializeField] private float BashTime;
    // [SerializeField] private GameObject Arrow;
    // Vector3 BashDir;
    // private float BashTimeReset;
    // GameObject arrow;

    //  void Start()
    // {
    //      BashTimeReset = BashTime;

    //     _rb = GetComponent<Rigidbody2D>();      
    // }

    // void Update()
    // {
    //     Bash();
    //     Jump();
    // }
    // private void Jump()
    // {
    //     if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         _rb.AddForce(Vector2.up *1500f);
    //     }

    // }
    //  void Bash()
    // {  //Check if nearObject
    //     RaycastHit2D[] Rays = Physics2D.CircleCastAll(transform.position, Raduis,Vector3.forward);
    //     foreach(RaycastHit2D ray in Rays)
    //     {

    //         NearToBashAbleObj = false;

    //         if(ray.collider.tag =="BashableObject")
    //         {
    //             NearToBashAbleObj = true;
    //             BashAbleObj = ray.collider.transform.gameObject;
    //             break;
    //         }
    //     }


    //     if(NearToBashAbleObj)
    //     {
    //         BashAbleObj.GetComponent<SpriteRenderer>().color = Color.yellow;
    //         if(Input.GetKeyDown(KeyCode.E))
    //         {
    //             Time.timeScale = 0;
    //             BashAbleObj.transform.localScale = new Vector2(1.4f, 1.4f);
    //             arrow = ObjectPooling.Instant.GetObj(Arrow);
    //             arrow.transform.position = BashAbleObj.transform.transform.position;
    //             arrow.SetActive(true);

    //             IsChosingDir = true;
    //         }
    //         else if(IsChosingDir && Input.GetKeyUp(KeyCode.E))
    //         {
    //             Time.timeScale = 1f;
    //             BashAbleObj.transform.localScale = new Vector2(1, 1);
    //             IsChosingDir = false;
    //             IsBashing = true;
    //             _rb.velocity = Vector2.zero;
    //             transform.position = BashAbleObj.transform.position;
    //             BashDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //             BashDir.z = 0;
    //             if(BashDir.x >0 )
    //             {
    //                 transform.eulerAngles = new Vector3(0, 0, 0);
    //             }
    //             else
    //             {
    //                 transform.eulerAngles = new Vector3(0, 180, 0);
    //             }
    //             BashDir = BashDir.normalized;
    //             BashAbleObj.GetComponent<Rigidbody2D>().AddForce(-BashDir * 50, ForceMode2D.Impulse);
    //             arrow.SetActive(false);

    //         }
    //     }
    //     else if (BashAbleObj != null)
    //     {
    //         BashAbleObj.GetComponent<SpriteRenderer>().color = Color.white;
    //     }

    //     ////// Preform the bash
    //     ///
    //     if(IsBashing)
    //     {
    //         if(BashTime > 0 )
    //         {
    //             BashTime -= Time.deltaTime;
    //             _rb.velocity = BashDir * BashPower * Time.deltaTime;
    //         }
    //         else
    //         {
    //             IsBashing = false;
    //             BashTime = BashTimeReset;
    //             _rb.velocity = new Vector2(_rb.velocity.x, 0);


    //         }
    //     }
    // }

    // void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(transform.position, Raduis);
    // }

    


    
 #endregion


 #region SkilCombo

 [SerializeField ]List<Color> colors= new List<Color>();
 private int  skillCounter  = 1;
 [SerializeField] private float skillResetTime = 1f;
 private float _lastTimeClicked = 0;
 [SerializeField] private float transitionTime  = 0.5f;
 SpriteRenderer spriteRenderer;

private void Start()
{
   spriteRenderer = this.GetComponent<SpriteRenderer>();

}
 private void Update()
 {
     if(Time.time - _lastTimeClicked >= skillResetTime || skillCounter ==colors.Count)
     {
        skillCounter = 0;
        spriteRenderer.color = colors[skillCounter];
     }
     //Check if aniatmion clip finishih
     if(Input.GetMouseButtonDown(0) && Time.time -_lastTimeClicked >= transitionTime)
     {
        spriteRenderer.color = colors[skillCounter];
        skillCounter++;
        _lastTimeClicked = Time.time;
     }
 }
 


 
    
 #endregion











}
 