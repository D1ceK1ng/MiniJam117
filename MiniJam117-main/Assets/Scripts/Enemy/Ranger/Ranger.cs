using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : Enemy
{
    [SerializeField] private float _range = 4;
    [SerializeField] private float _stopDistance = 8;
    [SerializeField] private CreatorBullet _creatorBullet;
    private bool _isCoolDown = true;
    private float _coolDownTime = 3;
    public override IMovable IMovable => _iMovable;
    public override IAttackable IAttackable =>_iAttackable;
    public override float Damage { get => _damage; set => _damage = value; }
    public override float Speed { get => _speed; set => _speed = value; }
    public override Health Health => _health;
    private void OnEnable() 
    {
       _iAttackable = new RangerAttack(_player.Health, transform, _player.transform,_range,_creatorBullet);
      _iMovable = new RangerMovement(transform, _player.transform,_canvas,  Speed, _stopDistance, _animator);
    }
    private void FixedUpdate() 
    {
        if(_isCoolDown)
        {
         _iAttackable.Attack(Damage);
         StartCoroutine(CoolDown());
        }
    }
    private IEnumerator CoolDown()
    {
        _isCoolDown = false;
        yield return new WaitForSeconds(_coolDownTime);
        _isCoolDown = true;
    }
}
