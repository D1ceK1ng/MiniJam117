using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private IMovable _iMovable;
    private void Awake() 
    {
        _iMovable = new PlayerMovement(transform,_speed, _rigidbody2D);
    }
    private void FixedUpdate() 
    {
        _iMovable.Move();
    }
}
