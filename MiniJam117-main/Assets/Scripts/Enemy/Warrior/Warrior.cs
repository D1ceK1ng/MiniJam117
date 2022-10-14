using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Enemy
{
    private Player _player;
    public override IMovable IMovable => _iMovable;
    public override float Speed { get => _speed; set => _speed = value; }
    private void Awake() 
    {
      _player = FindObjectOfType<Player>();
      _iMovable = new DirectedEnemyMovement(transform, _player.transform, Speed);
    }
}
