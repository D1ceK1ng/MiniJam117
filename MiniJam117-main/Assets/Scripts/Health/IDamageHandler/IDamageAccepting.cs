using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAccepting 
{
  public void TakeDamage(ref float health, float damage);
}
