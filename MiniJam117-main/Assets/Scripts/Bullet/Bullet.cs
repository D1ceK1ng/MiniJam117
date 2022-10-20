using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TimerOfGameObject))]
public class Bullet : MonoBehaviour, IStoppable
{
    [SerializeField] private float _destroyTime = 0.6f;
    [SerializeField] private float _damage = 4;
    [SerializeField] private float _speed = 3;
    private TimerOfGameObject _timerOfGameObject;
    private bool _canMove = true;
    public float Damage { get => _damage; set => _damage = value; }
    private void OnEnable() 
    {
        Pause.AddEntitie(this);
    }
    private void Start() 
    {
        _timerOfGameObject = GetComponent<TimerOfGameObject>();
        _timerOfGameObject.SetTimer(_destroyTime, Destroy);
    }
    private void Destroy() => Destroy(gameObject);
    private void Update() 
    {
      if(_canMove)
      {
      transform.Translate(Vector2.right * _speed * Time.deltaTime);
      }
    }
    public void StopEntitie()
    {
        _canMove = false;
    }

    public void PlayEntitie()
    {
      _canMove = true;
    }
}
