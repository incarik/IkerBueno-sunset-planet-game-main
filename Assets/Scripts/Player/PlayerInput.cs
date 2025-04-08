using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private KeyCode _left = KeyCode.A;
    [SerializeField] private KeyCode _right = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _fly = KeyCode.Space;
    [SerializeField] private KeyCode _attack = KeyCode.F;
    [SerializeField] private KeyCode _pause = KeyCode.Escape;

    public float InputVector => _xInput;
    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public bool Isflying { get => _isFlyinng; set => _isFlyinng = value; }
    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }
    public bool IsPausing { get => _isPausing; set => _isPausing = value; }

    private bool _isJumping;
    private bool _isFlyinng;
    private bool _isAttacking;
    private bool _isPausing;
    private float _xInput;
    
    public void HandleInput()
    {
        _xInput = 0;

        if (Input.GetKey(_left))
        {
            _xInput--;
        }

        if (Input.GetKey(_right))
        {
            _xInput++;
        }

        _isJumping = Input.GetKeyDown(_jump);
        _isFlyinng = Input.GetKey(_fly);
        _isAttacking = Input.GetKeyDown(_attack);
    }

    private void Update()
    {
        if(GameManager.instance.currentGameState == GameManager.GameState.Playing || GameManager.instance.currentGameState == GameManager.GameState.Pause)
        {
            _isPausing = Input.GetKeyDown(_pause);
        }

        if(GameManager.instance.currentGameState != GameManager.GameState.Playing)
        {
            _xInput = 0;
            _isJumping = false;
            _isFlyinng = false;
            _isAttacking = false;
            return;
        }

        HandleInput();
    }
}
