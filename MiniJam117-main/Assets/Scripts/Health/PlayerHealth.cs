using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private float _coolDownTime = 1; 
    public override IDamageAccepting IDamageAccepting { get; set; }
    private bool _isReloaded = true;
    private void Awake() 
    {
        IDamageAccepting = new SimpleDamageHandler();
    }
    public override void TryApplyingDamage(float damage)
    {
        if(_isReloaded)
        {
        ApplyDamage(damage);
        StartCoroutine(CoolDown());
        }
    }
   private IEnumerator CoolDown()
   {
    _isReloaded = false;
    yield return new WaitForSeconds(_coolDownTime);
    _isReloaded = true;
   }

}
