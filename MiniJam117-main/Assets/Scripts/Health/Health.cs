using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Health : MonoBehaviour
{
   [SerializeField] private float _currentHealth = 5;
   private float _maxHealth;
   public event Action OnChangeHealth;
   public event Action OnDestroy;
   public abstract IDamageAccepting IDamageAccepting { get; set; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float MaxHealth =>_maxHealth;
    private void OnEnable() 
    {
        _maxHealth = CurrentHealth;
    }
    public abstract void TryApplyingDamage(float damage);
   private protected void ApplyDamage(float damage)
   {
     IDamageAccepting.TakeDamage(ref _currentHealth, damage);
     OnChangeHealth?.Invoke();
     if (CurrentHealth <= 0)
     {
        OnDestroy?.Invoke();
     }
   }
}