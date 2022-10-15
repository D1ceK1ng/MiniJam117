using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
     public Health Health {get;set;}
     public void Attack(float damage);
}
