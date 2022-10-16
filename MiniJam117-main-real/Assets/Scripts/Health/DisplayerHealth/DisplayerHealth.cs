using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class DisplayerHealth<T> : MonoBehaviour where T : Health
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private T Health;
    private void Awake() 
    {
        Health.OnChangeHealth += DisplayHealth;
    }
    private void Start() 
    {
      DisplayHealth();
    }
    private void DisplayHealth()
    {
      _healthBar.DivideImageBar(Health.MaxHealth, Health.CurrentHealth);   
    }
    private void OnDisable() 
    {
       Health.OnChangeHealth -= DisplayHealth;
    }
}
