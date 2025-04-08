using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerAttack;
    public static event Action OnPlayerJump;
    public static event Action OnPause;

    private PlayerInput _playerInput;
    private Rigidbody2D _rBody;

    [Header("Movement")]
    [Tooltip("Horizontal speed")]
    [SerializeField] private float _moveSpeed = 5f;
    [Tooltip("Max height to jump")]
    [SerializeField] private float _jumpHeight = 1.25f;
    [SerializeField] private bool _doubleJump = true;

    [Header("Ground Sensor")]
    [SerializeField] private float _sensorRadius = 0.5f;
    [SerializeField] private float _sensorOffset = 0.15f;
    [SerializeField] private LayerMask _groundLayers;

    [SerializeField] private float _flyDelay = 1;
    [SerializeField] private float _flyTimer = 0;

    [SerializeField] private Vector3 _spawnPoint;

    void OnEnable()
    {
        CheckPoint.OnCheckPoint += UpdateSpawnPoint;
        PlayerHealth.OnPlayerDeath += ReSpawn;
    }
    void OnDisable()
    {
        CheckPoint.OnCheckPoint -= UpdateSpawnPoint;
        PlayerHealth.OnPlayerDeath -= ReSpawn;
    }

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerInput.IsPausing)
        {
            OnPause?.Invoke();
        }

        if(_playerInput.IsJumping)
        {
            Jump();
        }

        if(!IsGrounded() && !_doubleJump)
        {
            FlyWaitTime();
        }

        if(_playerInput.Isflying && !IsGrounded() && !_doubleJump)
        {
            Fly();
        }

        if(_playerInput.IsAttacking)
        {
            OnPlayerAttack?.Invoke();
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _rBody.velocity = new Vector2(_playerInput.InputVector * _moveSpeed, _rBody.velocity.y);

        if(_playerInput.InputVector < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(_playerInput.InputVector > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Jump()
    {
        if(IsGrounded())
        {
            _flyTimer = 0;
            _doubleJump = true;
            //_rBody.AddForce(Vector2.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
            JumpForce();
        }
        else if(!IsGrounded() && _doubleJump)
        {
            _doubleJump = false;
            //_rBody.AddForce(Vector2.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
            JumpForce();
        }

        /*if(OnPlayerJump != null)
        {
            OnPlayerJump();
        }*/
    }

    void JumpForce()
    {
        _rBody.AddForce(Vector2.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);

        OnPlayerJump?.Invoke();
    }

    void FlyWaitTime()
    {
        if(_flyTimer < _flyDelay)
        {
            _flyTimer += Time.deltaTime;
        }
    }

    void Fly()
    {
        if(_flyTimer >= _flyDelay)
        {
            _rBody.velocity = new Vector2(_rBody.velocity.x, _rBody.velocity.y / 2);
        }
    }

    bool IsGrounded()
	{
        Vector2 circlePosition = new Vector2(transform.position.x, transform.position.y + _sensorOffset);
		return Physics2D.OverlapCircle(circlePosition, _sensorRadius, _groundLayers);
	}

    void UpdateSpawnPoint(Vector3 spawn)
    {
        _spawnPoint = spawn;
    }

    void ReSpawn()
    {
        transform.position = _spawnPoint;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        IInteractable interactable = collider.GetComponent<IInteractable>();
        if(interactable != null)
        {
            interactable.Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + _sensorOffset, transform.position.z), _sensorRadius);
    }
}
