using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleAttack : IAttackable
{
    public Health Health {get;set;}
    public void Attack(float damage)
    {
        Health.TryApplyingDamage(damage);
    }
    public MiddleAttack(Health health)
    {
        Health = health;
    }
}
