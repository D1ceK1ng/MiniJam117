using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override IDamageAccepting IDamageAccepting { get; set; }
    private void Awake() 
    {
        IDamageAccepting = new SimpleDamageHandler();
        OnDestroy += DestroyEnemy;
    }
    public override void TryApplyingDamage(float damage)
    {
        ApplyDamage(damage);
    }
    private void DestroyEnemy() => Destroy(gameObject);
    private void OnDisable() 
    {
        OnDestroy -= DestroyEnemy;
    }
}
