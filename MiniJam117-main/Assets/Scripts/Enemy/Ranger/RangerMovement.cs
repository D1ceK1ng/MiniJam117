using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerMovement : IMovable
{
    public float Speed { get; set; }
   public Transform CurrentTransform {get;set;}
   private Transform _target;
   private Transform _healthBarTransform;
   private float _localScaleX;
   private float _healthBarLocalX;
   private float _range;
   private float _speed;
   private Animator _animator;
   public bool CanMove { get; set; }= true;
   public void Move()
   {
    if(CanMove)
    {
    float additionalSpeed = Vector2.Distance(CurrentTransform.position, _target.position) < _range ? 0 : 1;
    float currentSpeed = _speed * additionalSpeed;
    CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position,_target.position, Time.deltaTime * currentSpeed);
    float value =CurrentTransform.position.x > _target.position.x ? 1 : -1;
    _animator.SetFloat("speed", currentSpeed);
    _healthBarTransform.localScale = new Vector2(_healthBarLocalX * value * -1,_healthBarTransform.localScale.y);
    CurrentTransform.localScale = new Vector2(_localScaleX * value,CurrentTransform.localScale.y);
    }
   }

    public void StopEntitie()
    {
        CanMove = false;
    }

    public void PlayEntitie()
    {
      CanMove = true;
    }
    public RangerMovement(Transform enemyPoint, Transform target, Transform healthBar, float speed, float range,Animator animator)
   {
    _animator = animator;
    _speed = speed;
    _range = range;
    _localScaleX =enemyPoint.localScale.x;
    _healthBarLocalX = healthBar.localScale.x;
      _healthBarTransform = healthBar;
    CurrentTransform = enemyPoint;
    _target = target;
    Speed = speed;
    Pause.AddEntitie(this);
   }
}
