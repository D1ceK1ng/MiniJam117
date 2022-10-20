using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyHealth))]
public abstract class Enemy : MonoBehaviour
{
    private protected Player _player;
    [SerializeField] private protected Animator _animator;
    [SerializeField] private protected Transform _canvas;
    [SerializeField] private protected float _speed = 1;
    [SerializeField] private protected float _damage = 3;
    [SerializeField] private protected Health _health;
    private protected EntitieAnimator _entitieAnimator;
    protected IMovable _iMovable;
    protected IAttackable _iAttackable;
    public abstract Health Health {get;}
    public abstract IAttackable IAttackable {get;}
    public abstract IMovable IMovable {get;}
    public abstract float Speed {get;set;}
    public abstract float Damage {get;set;}
    private void Awake() 
    {
      _player = FindObjectOfType<Player>();
    _entitieAnimator = new EntitieAnimator(_animator);
    }
    private void Update() 
    {
        IMovable.Move();
    }
    private void OnDestroy() 
    {
          Pause.RemoveEntitie(_entitieAnimator);
    }

}
