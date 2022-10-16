using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerAttack : IAttackable
{
    public Health Health {get;set;}
    private Transform _currentTransform;
    private Transform _playerTransform;
    private CreatorBullet _creatorBullet;
    private float _range;
    public void Attack(float damage)
    {
        if (Vector3.Distance(_currentTransform.transform.position, _playerTransform.position) <= _range)
        {
            _creatorBullet.CreateBullet((_playerTransform.transform.position - _currentTransform.transform.position));
        }
    }
    public RangerAttack(Health health, Transform currentTransform, Transform playerTransform, float range, CreatorBullet creatorBullet)
    {
        _playerTransform = playerTransform;
        _currentTransform = currentTransform;
        Health = health;
        _range = range;
        _creatorBullet = creatorBullet;
    }
}
