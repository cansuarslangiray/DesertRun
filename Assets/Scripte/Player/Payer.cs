using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Payer : MonoBehaviour
{
    [SerializeField] private float leftRightSpeed = 4f;

    private Animator _animator;
    private CharacterController _characterController;
    private Rigidbody _rigidbody;

    public float initialSpeed = 3.0f; // The starting speed of the player.
    public float maxSpeed = 45.0f; // The maximum speed the player can reach.
    public float speedIncreaseInterval = 50.0f; // How often to increase speed.
    public float speedIncreaseAmount = 1.0f; // How much to increase speed each time.

    private float _currentSpeed;
    private float _timer;
    private bool _isJumping;
    private Vector3 _currentJumpVelocity;
    public static bool IsDead =false;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _currentSpeed = initialSpeed;
        _timer = 0f;
    }

    private void Update()
    {
        if (!IsDead)
        {
            CharacterControllerMovement();
        }
    }


    private void CharacterControllerMovement()
    {
        _timer += Time.deltaTime;

        // Check if it's time to increase speed.
        if (_timer >= speedIncreaseInterval)
        {
            _currentSpeed += speedIncreaseAmount;

            _currentSpeed = Mathf.Min(_currentSpeed, maxSpeed);

            _timer = 0f;
        }

        leftRightSpeed = _currentSpeed + 1;
        Vector3 moveVelocity = Vector3.zero;

        moveVelocity.x = Input.GetAxis("Horizontal") * leftRightSpeed;
        moveVelocity.z = _currentSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            if (!_isJumping)
            {
                _isJumping = true;
                _animator.SetBool("IsJumping", true);
                _currentJumpVelocity = Vector3.up * 5;
            }
        }

        if (_isJumping)
        {
            _characterController.Move((moveVelocity + _currentJumpVelocity) * Time.deltaTime);
            _currentJumpVelocity += Physics.gravity * Time.deltaTime;
            if (_characterController.isGrounded)
            {
                _isJumping = false;
                _animator.SetBool("IsJumping", false);
            }
        }
        else
        {
            _characterController.SimpleMove(moveVelocity);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("olllummmm");
            _animator.SetTrigger("IsDead");
            IsDead = true;
        }
    }
}