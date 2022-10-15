using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
   [SerializeField] private Bullet _bullet;
   private void OnTriggerStay2D(Collider2D other) 
   {
     other.TriggerEntity<Enemy>(e=>
     {
         IAttackable attackable = new MiddleAttack(e.Health);
        attackable.Attack(_bullet.Damage);
     });
   }
}
