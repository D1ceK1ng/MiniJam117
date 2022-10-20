using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : IMovable
{
    private Rigidbody2D _rigidbody2D;
    private PlayerController _playerInput;
    private Vector2 _playerVector;
    private float _additionalSpeedValue =1;
    public float Speed { get; set; }
    public Transform CurrentTransform { get; set; }
    public bool CanMove { get; set; } = true;
    public void Move()
    {
        _rigidbody2D.AddForce(_playerVector * Speed * _additionalSpeedValue);
    }
    public PlayerMovement(Transform currentPoint, float speed, Rigidbody2D rigidbody2D)
    {
        CurrentTransform = currentPoint;
        _rigidbody2D = rigidbody2D;
        Speed = speed;
        _playerInput = new();
        _playerInput.PlayerInput.Movement.started += OnMove;
        _playerInput.PlayerInput.Movement.performed += OnMove;
        _playerInput.PlayerInput.Movement.canceled += OnMove;
        _playerInput.PlayerInput.Enable();
        Pause.AddEntitie(this);
    }
    public void StopEntitie()
    {
        CanMove = false;    
        _additionalSpeedValue = 0;
        if(_rigidbody2D != null)
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    public void PlayEntitie()
    {
        CanMove = true;
        _additionalSpeedValue = 1;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        if(CanMove)
        {
        _playerVector = context.ReadValue<Vector2>();
        }
    }
}
