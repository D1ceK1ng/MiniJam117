using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedEnemyMovement : IMovable
{
     private Transform _target;
   private Transform _healthBarTransform;
   private float _localScaleX;
   private float _healthBarLocalX;
   public float Speed { get; set; }
   public Transform CurrentTransform {get;set;}
  public bool CanMove { get; set; }= true;
   public void Move()
   {
    if(CanMove)
    {
    CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position,_target.position, Time.deltaTime * Speed);
    float value =CurrentTransform.position.x > _target.position.x ? 1 : -1;
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
   public DirectedEnemyMovement(Transform enemyPoint, Transform target, Transform healthBar, float speed)
   {
      _localScaleX =enemyPoint.localScale.x;
    _healthBarLocalX = healthBar.localScale.x;
      _healthBarTransform = healthBar;
    CurrentTransform = enemyPoint;
    _target = target;
    Speed = speed;
    Pause.AddEntitie(this);
   }
}
