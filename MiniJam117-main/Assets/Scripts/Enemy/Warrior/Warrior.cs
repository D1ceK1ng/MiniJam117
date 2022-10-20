using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Enemy
{
    public override IMovable IMovable => _iMovable;
    public override IAttackable IAttackable =>_iAttackable;
    public override float Damage { get => _damage; set => _damage = value; }
    public override float Speed { get => _speed; set => _speed = value; }
    public override Health Health => _health;
    private void OnEnable() 
    {
       _iAttackable = new MiddleAttack(_player.Health);
      _iMovable = new DirectedEnemyMovement(transform, _player.transform,_canvas, Speed);
    }
}
