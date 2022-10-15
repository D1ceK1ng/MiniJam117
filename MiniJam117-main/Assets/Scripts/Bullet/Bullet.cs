using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 0.6f;
    [SerializeField] private float _damage = 4;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public float Damage => _damage;
    private void Start() 
    {
        Destroy(gameObject,_destroyTime);
    }
    public void Move(float fireRange,Vector2 bulletAngle, float bulletForce)
    {
      _rigidbody2D.AddForce(fireRange * bulletForce * bulletAngle, ForceMode2D.Impulse);
    }

}
