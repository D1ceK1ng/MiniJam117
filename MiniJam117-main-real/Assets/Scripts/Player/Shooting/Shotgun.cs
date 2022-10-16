using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private int _bulletCount;
    [SerializeField] private float _timeForReloading = 0.5f;
    [SerializeField] private CreatorBullet _creatorBullet;
    private PlayerController _playerInput;
    private bool _canShoot;
    private float _cooldown;
    private void Awake()
    {
        _playerInput = new PlayerController();
        _playerInput.PlayerInput.Shoot.started += OnShoot;
        _playerInput.PlayerInput.Shoot.canceled += OnShoot;
    }
    private void OnEnable()
    {
        _playerInput.PlayerInput.Enable();
    }
    private void Update()
    {
        _cooldown += Time.deltaTime;
    }
    private void OnShoot(InputAction.CallbackContext obj)
    {
        _canShoot = obj.ReadValueAsButton() && _cooldown > _timeForReloading;
        if (_canShoot)
        {
         Shoot();
        }
    }
    private void Shoot()
    {
       Vector2 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position ;
        for (int i = 0; i < _bulletCount; i++)
        {
            _creatorBullet.CreateBullet(distance);
        }
        _cooldown = 0;
    }
    private void OnDisable()
    {
        _playerInput.PlayerInput.Disable();
    }

}
