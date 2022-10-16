using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletTrigger : BulletTrigger<EnemyHealth>
{
  private LoaderAbilities _loaderAbilities;
 private void Awake() 
 {
    _loaderAbilities = FindObjectOfType<LoaderAbilities>();
    DamagableAbility damagableAbility= (DamagableAbility)_loaderAbilities.LoadedAbilities.Find(e=>e.CurrentTypeOfStat == TypeOfStat.Damagable); 

    _bullet.Damage *= damagableAbility.ProcentOfAdditonalDamage;
 }
}
