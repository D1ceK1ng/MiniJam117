using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : Trigger
{
    [SerializeField] private Enemy _enemy;
   private void OnTriggerStay2D(Collider2D other) 
   {
     other.TriggerEntity<Player>(e=>
     {
        _enemy.IAttackable.Attack(e.Damage);
     });
   }
}
