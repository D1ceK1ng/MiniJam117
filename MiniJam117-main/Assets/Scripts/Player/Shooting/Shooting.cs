using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;


    public float BulletForce;

  
    private PlayerController _playerInput;
    private bool _canShoot;
    private const float FireRange = 4f;

    void Awake()
    {
        _playerInput = new PlayerController();
        _playerInput.PlayerInput.Shoot.started += OnShoot;
        _playerInput.PlayerInput.Shoot.canceled += OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        _canShoot = obj.ReadValueAsButton();

        if (_canShoot)
            Shoot();
    }

    void OnEnable()
    {
        _playerInput.PlayerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.PlayerInput.Disable();
    }
   
    
    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        Vector2 distance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(FireRange * distance.normalized * BulletForce, ForceMode2D.Impulse);
    }
}
