using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Health _health;
    private IMovable _iMovable;
    public Health Health => _health;
    public float Damage => _damage;
    private void Awake() 
    {
        _iMovable = new PlayerMovement(transform,_speed, _rigidbody2D);
    }
    private void FixedUpdate() 
    {
        _iMovable.Move();
    }
}
