using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{

    private const int Speed = 400;
    private PlayerController _playerInput;
    private Vector2 _playerMovement;
    private Vector2 _playerMovementInput;
    private Rigidbody2D _rigidbody;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = new();

        _playerInput.PlayerInput.Movement.started += OnMove;
        _playerInput.PlayerInput.Movement.performed += OnMove;
        _playerInput.PlayerInput.Movement.canceled += OnMove;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_playerMovement * Speed * Time.deltaTime);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _playerMovementInput = context.ReadValue<Vector2>();
        _playerMovement = _playerMovementInput;
    }

    private void OnEnable()
    {
        _playerInput.PlayerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.PlayerInput.Disable();
    }


}
