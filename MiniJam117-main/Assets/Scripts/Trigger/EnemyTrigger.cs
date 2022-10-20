using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : Trigger
{
    [SerializeField] private Enemy _enemy;
    private void OnCollisionStay2D(Collision2D other) 
    {
      if(_canBeStopped)
      {
       other.collider.TriggerEntity<Player>(e=>
       {
        _enemy.IAttackable.Attack(_enemy.Damage);
       });
      }
    }
}
