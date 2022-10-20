using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Health _health;
    private IMovable _iMovable;
    public Health Health => _health;
    public float Damage => _damage;
    private LoaderAbilities _loaderAbilities;
    private void Awake() 
    {
        _loaderAbilities = FindObjectOfType<LoaderAbilities>();
        Health.OnSetMaxHealth += SetCurrentHealth;
        _iMovable = new PlayerMovement(transform,_speed, _rigidbody2D);
    }
    private void Start()
    {

    }
    private void SetCurrentHealth()
    {
        SavableHealth savableHealth = Loader<SavableHealth>.Load(new SavableHealth());
        if (savableHealth != null )
        {
            if(savableHealth.Health != "")
            {
            _health.CurrentHealth = float.Parse(savableHealth.Health);
            HealingAbility healingAbility= (HealingAbility)_loaderAbilities.LoadedAbilities.Find(e=>e.CurrentTypeOfStat == TypeOfStat.Healing); 
            _health.MaxHealth *= healingAbility.ProcentOfAdditonalHealth;
            _health.CurrentHealth *= healingAbility.ProcentOfAdditonalHealth;
            }
        }
    }
    private void FixedUpdate() 
    {
        _iMovable.Move();
    }
    private void OnDisable() 
    {
         Health.OnSetMaxHealth -= SetCurrentHealth; 
    }
  
}
