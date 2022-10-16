using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorFactory : GenericFactory<Warrior>,IEnemyFactory
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector2 _additionalTime = new Vector2(5,10);
    private EnemyCreator _enemyCreator;
    public event Action<Enemy> OnCreateEnemy;
    private void OnEnable() 
    {
         _enemyCreator = new EnemyCreator();
         StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        OnCreateEnemy?.Invoke(InstantiateObject(_enemyCreator.RandomCircle(_player.transform.position)));
        yield return new WaitForSeconds(_enemyCreator.GetRandomTime(_additionalTime));
        StartCoroutine(CoolDown());
    }

}
