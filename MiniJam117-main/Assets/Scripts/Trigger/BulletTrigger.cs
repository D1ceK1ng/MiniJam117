using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletTrigger<T> : Trigger where T : Health
{
   [SerializeField] private protected Bullet _bullet;
   private void OnTriggerEnter2D(Collider2D other) 
   {
      if(_canBeStopped)
      {
     other.TriggerEntity<T>(e=>
     {
         IAttackable attackable = new MiddleAttack(e);
        attackable.Attack(_bullet.Damage);
        Destroy(gameObject);
     });
      }
   }
}
