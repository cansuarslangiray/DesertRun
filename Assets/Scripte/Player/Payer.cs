using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Payer : MonoBehaviour
{
    [SerializeField] private float leftRightSpeed = 4f;
    private bool _isJumping = false;
    public GameObject feet;

    private Animator _animator;
    private CharacterController _characterController;
    private Rigidbody _rigidbody;

    public float initialSpeed = 3.0f; // The starting speed of the player.
    public float maxSpeed = 45.0f; // The maximum speed the player can reach.
    public float speedIncreaseInterval = 50.0f; // How often to increase speed.
    public float speedIncreaseAmount = 1.0f; // How much to increase speed each time.
    public static bool isOnFloor = true;
    
    private float _currentSpeed;
    private float _timer;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _currentSpeed = initialSpeed;
        _timer = 0f;
    }

    private void Update()
    {
        Debug.DrawRay(feet.transform.position, Vector3.down/2, Color.red);
        Movement();
    }

    private void Movement()
    {
        _timer += Time.deltaTime;

        // Check if it's time to increase speed.
        if (_timer >= speedIncreaseInterval)
        {
            _currentSpeed += speedIncreaseAmount;

            _currentSpeed = Mathf.Min(_currentSpeed, maxSpeed);

            _timer = 0f;
        }

        transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime, Space.World);
        leftRightSpeed = _currentSpeed + 1;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.LeftSide)
            {
                transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
            }
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.RightSide)
            {
                transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool("IsJumping", !isOnFloor);
            _rigidbody.AddForce(transform.up * 5f);
            IsGrounded();
        }
    }

    private void IsGrounded()
    {
       /* var position = feet.transform.position;
        if (Physics.Raycast(position, Vector3.down, 1f))
        {
            Debug.Log("HEYY");
            _isJumping = false;
            _animator.SetBool("IsJumping", false);
        }*/
    }
}