using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedEnemyMovement : IMovable
{
   public float Speed { get; set; }
   public Transform CurrentTransform {get;set;}
   private Transform _target;
   public void Move()
   {
    CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position,_target.position, Time.deltaTime * Speed);
   }
   public DirectedEnemyMovement(Transform enemyPoint, Transform target, float speed)
   {
    CurrentTransform = enemyPoint;
    _target = target;
    Speed = speed;
   }
}
