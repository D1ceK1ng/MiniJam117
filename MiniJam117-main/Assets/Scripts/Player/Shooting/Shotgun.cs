using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : MonoBehaviour
{
  [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletForce = 2;
    [SerializeField] private float _fireRange = 4f;
    private PlayerController _playerInput;
    private bool _canShoot;
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

    private void OnShoot(InputAction.CallbackContext obj)
    {
        _canShoot = obj.ReadValueAsButton();
        if (_canShoot)
        {
         Shoot();
        }
    }
    private void Shoot()
    {
        Vector2 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        bullet.Move(_fireRange,distance,_bulletForce);
    }
    private void OnDisable()
    {
        _playerInput.PlayerInput.Disable();
    }

}
