using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletForce = 2;
    [SerializeField] private float _fireRange = 4f;
    [SerializeField] private int _bulletCount;
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

    void Update()
    {
        _cooldown += Time.deltaTime;
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        _canShoot = obj.ReadValueAsButton() && _cooldown > .5f;
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
            Vector2 bulletAngle = distance + new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));

            Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);

            bullet.Move(_fireRange, bulletAngle.normalized, _bulletForce);
        }

        _cooldown = 0;

    }
    private void OnDisable()
    {
        _playerInput.PlayerInput.Disable();
    }

}
