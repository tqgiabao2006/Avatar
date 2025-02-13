using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Core
{

    #region  State Machine
    //    [SerializeField] public State_Base _state;
    public Moveable_Platform_State _platform_State;

    public Idle_State _idle_State;
    public Run_State _run_State;
    public Air_State _air_State;
    public Neutrual _neutralJump_State;
    public WallJump_State _wallJump_State;

    public Fail_State _fall_State;

    public State_Base _wallGrab_State;

    public WallSlide_State _wallSlide_State;
    public WallRun_State _wallRun_State;

    public Dash_State _dash_State;

    public Player_SkillSystem _skill_State;

    public JumpAttack_State _jumpAttackState;


    private State_Base _oldState;

    #endregion

    #region New StateMachine

    public PlayerController _playerController;
    public Ground_State _ground_State;
    public OnAir_State _onAir_State;
    public OnWall_State _onWall_State;

    #endregion
    //Variables && Components
    #region Components
    [Header("Components")]
    // public Rigidbody2D _rb;
    // public  Animator _anim;
    public SpriteRenderer _spriteRenderer;
    public Collider2D _colli;

    #endregion
    #region LayerMasks Variables
    [Header("Layer Masks")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] public LayerMask _wallLayer;
    [SerializeField] private LayerMask _cornerCorrectLayer;

    [SerializeField] public LayerMask _moveablePlatformLayer;
    #endregion
    #region Movement Variables
    [Header("Movement Variables")]
    [SerializeField] public float _movementAcceleration = 70f;
    [SerializeField] public float _maxMoveSpeed = 12f;
    [SerializeField] public float _groundLinearDrag = 7f;

    public float _horizontalDirection { get; private set; }
    public float _verticalDirection { get; private set; }
    public bool _changingDirection => (_rb.velocity.x > 0f && _horizontalDirection < 0f) || (_rb.velocity.x < 0f && _horizontalDirection > 0f);
    public bool _facingRight = true;
    public bool _canMove => !_wallGrab;
    #endregion
    #region Jump Variables
    [Header("Jump Variables")]
    [SerializeField] public float _jumpForce = 12f;
    [SerializeField] public float _airLinearDrag = 2.5f;
    [SerializeField] public float _fallMultiplier = 8f;
    [SerializeField] public float _lowJumpFallMultiplier = 5f;
    [SerializeField] public float _downMultiplier = 12f;
    [SerializeField] public int _extraJumps = 1;
    [SerializeField] public float _hangTime = .1f;
    [SerializeField] public float _jumpBufferLength = .1f;

    // Jump Coooldown
    [SerializeField] public float _jumpCoolDown = 1f;

    [field: SerializeField] public float _currentJumpTime;
    public int _extraJumpsValue;
    [SerializeField] public float _hangTimeCounter;
    public float _jumpBufferCounter;
    public bool _canJump => _jumpBufferCounter > 0f && (_hangTimeCounter > 0f || _extraJumpsValue > 0 || _onWall);
    public bool _isJumping = false;
    public bool _hasCalledJump;

    #endregion

    #region  JumpMario


    #endregion
    #region  Wall Movement Variables
    [Header("Wall Movement Variables")]
    [SerializeField] public float _wallSlideModifier = 0.5f;
    [SerializeField] public float _wallRunModifier = 0.85f;
    [SerializeField] public float _wallJumpXVelocityHaltDelay = 0.2f;
    [SerializeField] public float _wallRunCD;

    [SerializeField] public float _wallTopOffset;
    public float _currentWallRunCD;

    // private bool _wallGrab => _onWall && !_onGround && Input.GetButton("WallGrab") && !_wallRun;
    public bool _wallGrab => _onWall && !_onGround && Input.GetKey(KeyCode.E);
    public bool _wallSlide => _onWall && !_onGround && !Input.GetKey(KeyCode.E) && _rb.velocity.y < 0f && !_wallRun;
    public bool _wallRun => _wallGrab && GetInput() != Vector2.zero && _onWall;
    public int _faceChange = 0;
    #endregion
    #region Dash Variables
    //      [Header("Dash Variables")]
    //     [SerializeField] public float _dashSpeed = 15f;
    //     [SerializeField] public float _dashLength = .3f;
    //     [SerializeField]public float _dashBufferLength = .1f;
    //    public float _dashBufferCounter;
    //     public bool _isDashing;
    //     public bool _hasDashed;
    //     public float _dashDuration;
    //     public bool _canDash => _dashBufferCounter > 0f && !_hasDashed && _currenttDashCD <=0;

    //     [SerializeField] public float _dashCD = 2f;
    //   public float _currenttDashCD;

    #endregion
    #region Collision Checkd
    [Header("Ground Collision Variables")]
    [SerializeField] private float _groundRaycastLength;
    [SerializeField] private Vector3 _groundRaycastOffset;
    public bool _onGround;
    [Header("Wall Collision Variables")]
    [SerializeField] private float _wallRaycastLength;
    public bool _onWall;
    public bool _onRightWall;
    #endregion
    #region Conner Correction Variables
    [Header("Corner Correction Variables")]
    [SerializeField] private float _topRaycastLength;
    [SerializeField] private Vector3 _edgeRaycastOffset;
    [SerializeField] private Vector3 _innerRaycastOffset;
    private bool _canCornerCorrect;
    #endregion

    #region OnWayPlatformer
    private GameObject _currentOnWayPlatForm;

    #endregion
    #region Game FLow Function
    #region New Dash Variables
    [Header("New Dash Variables")]
    [SerializeField] public float dashDistance = 5f;
    [SerializeField] public float dashDuration = 0.2f;
    [SerializeField] public float dashCooldown = 1f;
    // [SerializeField]   public LayerMask obstacleMask; // Adjust this mask if you want to avoid certain objects during the dash
    public Vector3 dashDirection;
    public bool canDash = true;
    public bool isDashing = false;

    #endregion

    #region Moveable Platform
    [Header("Moveable Platform Variables")]
    [SerializeField] public string _objectTag = "MoveablePlatform";
    [SerializeField] public bool _onMoveablePlatform = false;

    public bool _isMovingPlatform;
    #endregion
    //Function: Update, Start, FixedUpdate
    #region Super Jump
    [Header("Super Jump")]

    [SerializeField] public float _maxJumpForce = 20f;
    [SerializeField] public float _maxHoldTime = 2f;
    [HideInInspector] public float holdTime = 0f;

    [HideInInspector] public bool _isChargingToJump;

    #endregion
    #region Ledge Climbing Variables
    [HideInInspector] public bool _ledgedDetected;
    [Header("Ledge Detection Variables")]
    [SerializeField] private Vector2 _offSet1;
    [SerializeField] private Vector2 _offSet2;

    private Vector2 _climbBegunPosition;
    private Vector2 _climbOverPosition;

    public bool _canGrabLedge = true;
    public bool _canClimb;


    #endregion

    #region Skill Varialbes
    public bool isSkilling;
    public bool isJUmpAttacking;
    #endregion


    private void Awake()
    {
        SetUpInstances();
        _spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _colli = this.GetComponent<Collider2D>();
        _machine = new MachineState();
        _machine.Set(_ground_State, true);
    }


    private void Update()
    {
        //Special Movement
        CheckCanJump();

        SelectState();
        Timer();
        _machine._state.FixedDo();
        _machine._state.FixedDoBranch();
        if (_onGround)
        {
            FLipDuringPlay();
            _isJumping = false;
        }
        // FallMultiplier();
        CheckingAdditional();

        _horizontalDirection = GetInput().x;
        _verticalDirection = GetInput().y;
    }
    #region State Machine Logic
    private void SelectState()
    {
        if (isJUmpAttacking)
        {
            _machine.Set(_jumpAttackState);
        }
        else
        {
            if ((Input.GetMouseButton(0) || isSkilling) && _onGround)
            {
                _machine.Set(_skill_State, true);
            }
            else if (!isSkilling)
            {
                if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
                {
                    // Get the direction from the combination of keys
                    dashDirection = GetDashDirection();
                    // Set Dash State
                    if (canDash)
                    {
                        _machine.Set(_dash_State);
                    }
                }
                else
                {
                    if (_playerController._onMoveablePlatform && Input.GetKey(KeyCode.E))
                    {
                        _machine.Set(_platform_State, true);
                        _isMovingPlatform = true;
                    }
                    else
                    {
                        _isMovingPlatform = false;

                    }
                    if (!isDashing && !_isMovingPlatform)
                    {
                        if (_canMove && _onGround && _rb.velocity.y == 0)
                        {
                            _machine.Set(_ground_State);
                            _hasCalledJump = false;

                        }
                        else _rb.velocity = Vector2.Lerp(_rb.velocity, (new Vector2(_horizontalDirection * _maxMoveSpeed, _rb.velocity.y)), .5f * Time.deltaTime);
                        if (_onWall)
                        {
                            _machine.Set(_onWall_State);
                            _hasCalledJump = false;
                        }
                        else if (_canJump)
                        {
                            _machine.Set(_onAir_State);
                            _isJumping = true;


                        }
                    }

                }
            }
        }
    }



    














    
    #endregion


    #region Ledge Climbing

    private void CheckForLedge()
    {
        if (_ledgedDetected && _canGrabLedge)
        {
            _canGrabLedge = false;
            Vector2 legdePosition = GetComponentInChildren<EdgeDetection>().transform.position;
            _climbBegunPosition = legdePosition + _offSet1;
            _climbOverPosition = legdePosition + _offSet2;

            _canClimb = true;

        }
        if (_canClimb)
        {
            this.transform.position = _climbBegunPosition;
        }

    }
    private void LedgeClimbOver()
    {
        _canClimb = false;
        transform.position = _climbOverPosition;
        Invoke("AllowLedgeClimb", .1f);
    }
    private void AllowLedgeClimb() => _canGrabLedge = true;


    #endregion


    #region Super Jump
    private void CheckCanJump()
    {
        // Check if the spacebar is being held down
        if (Input.GetKey(KeyCode.E))
        {
            holdTime += Time.deltaTime;
            if (holdTime > _maxHoldTime)
            {
                holdTime = _maxHoldTime;
            }

            _isChargingToJump = true;
        }

        // Check if the spacebar is release

        if (Input.GetKeyUp(KeyCode.E) && _isChargingToJump)
        {
            _isChargingToJump = false;
            _jumpBufferCounter = _jumpBufferLength;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isChargingToJump)
        {
            _jumpBufferCounter = _jumpBufferLength;

        }
        else
        {
            _jumpBufferCounter -= Time.deltaTime;
        }


    }



    #endregion
    private void FixedUpdate()
    {
        OnWayPlatformer();
        _machine._state.Do();
        _machine._state.DoBranch();
        CheckCollisions();
        if (!isDashing)
        {
            if (_canCornerCorrect) CornerCorrect(_rb.velocity.y);

            if (_onGround)
            {
                ApplyGroundLinearDrag();
                _extraJumpsValue = _extraJumps;
                _hangTimeCounter = _hangTime;
            }
            else
            {
                ApplyAirLinearDrag();
                FallMultiplier();
                _hangTimeCounter -= Time.fixedDeltaTime;
                if (!_onWall || _rb.velocity.y < 0f || _wallRun) _isJumping = false;
            }
        }

        if (!_onMoveablePlatform) _isMovingPlatform = false;

    }

    #endregion

    #region Timer
    private void Timer()
    {
        // _currenttDashCD -= Time.deltaTime;
        _currentJumpTime -= Time.deltaTime;
    }
    private void CheckingAdditional()
    {
        if (_onGround)
        {
            _faceChange = 0;

        }

    }
    #endregion
    //Logic in movements and movemts effect
    #region PlayerController Function

    #region Move
    public void ApplyGroundLinearDrag()
    {
        if (_isMovingPlatform) return;
        if (Mathf.Abs(_horizontalDirection) < 0.4f || _changingDirection)
        {
            _rb.drag = _groundLinearDrag;
        }
        else
        {
            _rb.drag = 0f;
        }
    }
    #endregion

    #region AirDrag
    public void ApplyAirLinearDrag()
    {
        _rb.drag = _airLinearDrag;
    }
    #endregion

    public void FallMultiplier()
    {
        if (_isMovingPlatform || isJUmpAttacking) return;
        if (_rb.velocity.y < -0.5f && !_onWall)
        {
            _rb.gravityScale = _fallMultiplier;
        }
        else if (!_wallGrab)
        {
            _rb.gravityScale = _lowJumpFallMultiplier;
        }
    }

    #region Dash Input
    private Vector3 GetDashDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            direction += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            direction -= new Vector2(0, 1);
        if (Input.GetKey(KeyCode.D))
            direction += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.A))
            direction -= new Vector2(1, 0);
        return direction.normalized;
    }
    #endregion



    private void FLipDuringPlay()
    {

        if (_rb.velocity.x < 0)
        {
            Quaternion rotation = this.transform.rotation;
            rotation.y = 180;
            this.transform.rotation = rotation;
            _facingRight = false;
        }
        else if (_rb.velocity.x > 0)
        {
            Quaternion rotation = this.transform.rotation;
            rotation.y = 0;
            this.transform.rotation = rotation;
            _facingRight = true;


        }

    }

    #endregion
    #region Logic
    void CornerCorrect(float Yvelocity)
    {
        //Push player to the right
        RaycastHit2D _hit = Physics2D.Raycast(transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength, Vector3.left, _topRaycastLength, _cornerCorrectLayer);
        if (_hit.collider != null)
        {
            float _newPos = Vector3.Distance(new Vector3(_hit.point.x, transform.position.y, 0f) + Vector3.up * _topRaycastLength,
                transform.position - _edgeRaycastOffset + Vector3.up * _topRaycastLength);
            transform.position = new Vector3(transform.position.x + _newPos, transform.position.y, transform.position.z);
            _rb.velocity = new Vector2(_rb.velocity.x, Yvelocity);
            return;
        }

        //Push player to the left
        _hit = Physics2D.Raycast(transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength, Vector3.right, _topRaycastLength, _cornerCorrectLayer);
        if (_hit.collider != null)
        {
            float _newPos = Vector3.Distance(new Vector3(_hit.point.x, transform.position.y, 0f) + Vector3.up * _topRaycastLength,
                transform.position + _edgeRaycastOffset + Vector3.up * _topRaycastLength);
            transform.position = new Vector3(transform.position.x - _newPos, transform.position.y, transform.position.z);
            _rb.velocity = new Vector2(_rb.velocity.x, Yvelocity);
        }
    }
    private void CheckCollisions()
    {
        //Ground Collisions
        _onGround = Physics2D.Raycast(transform.position + _groundRaycastOffset, Vector2.down, _groundRaycastLength, _groundLayer) ||
                    Physics2D.Raycast(transform.position - _groundRaycastOffset, Vector2.down, _groundRaycastLength, _groundLayer) || Physics2D.Raycast(transform.position + _groundRaycastOffset, Vector2.down, _groundRaycastLength, _wallLayer) ||
                    Physics2D.Raycast(transform.position - _groundRaycastOffset, Vector2.down, _groundRaycastLength, _wallLayer) || _onMoveablePlatform;

        //Corner Collisions
        _canCornerCorrect = Physics2D.Raycast(transform.position + _edgeRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer) &&
                            !Physics2D.Raycast(transform.position + _innerRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer) ||
                            Physics2D.Raycast(transform.position - _edgeRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer) &&
                            !Physics2D.Raycast(transform.position - _innerRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer);

        //Wall Collisions
        _onWall = Physics2D.Raycast(transform.position, Vector2.right, _wallRaycastLength, _wallLayer) ||
                    Physics2D.Raycast(transform.position, Vector2.left, _wallRaycastLength, _wallLayer);

        _onRightWall = Physics2D.Raycast(transform.position, Vector2.right, _wallRaycastLength, _wallLayer);

        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y + _wallTopOffset, this.transform.position.z);
        //Moveable Object collision
        _onMoveablePlatform = Physics2D.OverlapCircle(_playerController.transform.position, 2f, _playerController._moveablePlatformLayer);




    }

    private void OnWayPlatformer()
    {
        if (_verticalDirection < 0 && _currentOnWayPlatForm != null)
        {
            StartCoroutine(DisableCollision());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("OnWayPlatformer"))
        {
            _currentOnWayPlatForm = other.gameObject;


        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {


    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("OnWayPlatformer"))
        {
            _currentOnWayPlatForm = null;

        }


    }

    private IEnumerator DisableCollision()
    {
        Collider2D _platformerCollider = _currentOnWayPlatForm.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(_colli, _platformerCollider);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(_colli, _platformerCollider, false);

    }

    #endregion

    #region GetInput
    public Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        //Ground Check
        Gizmos.DrawLine(transform.position + _groundRaycastOffset, transform.position + _groundRaycastOffset + Vector3.down * _groundRaycastLength);
        Gizmos.DrawLine(transform.position - _groundRaycastOffset, transform.position - _groundRaycastOffset + Vector3.down * _groundRaycastLength);

        //Corner Check
        Gizmos.DrawLine(transform.position + _edgeRaycastOffset, transform.position + _edgeRaycastOffset + Vector3.up * _topRaycastLength);
        Gizmos.DrawLine(transform.position - _edgeRaycastOffset, transform.position - _edgeRaycastOffset + Vector3.up * _topRaycastLength);
        Gizmos.DrawLine(transform.position + _innerRaycastOffset, transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength);
        Gizmos.DrawLine(transform.position - _innerRaycastOffset, transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength);

        //Corner Distance Check
        Gizmos.DrawLine(transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength,
                        transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength + Vector3.left * _topRaycastLength);
        Gizmos.DrawLine(transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength,
                        transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength + Vector3.right * _topRaycastLength);

        //Wall Check
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * _wallRaycastLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * _wallRaycastLength);

        //Moveable Object Check

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, 1f);








    }
    #endregion

}

