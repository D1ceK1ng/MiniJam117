using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 0.6f;
    [SerializeField] private float _damage = 4;
    [SerializeField] private float _speed = 3;

    public float Damage { get => _damage; set => _damage = value; }

    private void Start() 
    {
        Destroy(gameObject,_destroyTime);
    }
    private void Update() 
    {
      transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

}
