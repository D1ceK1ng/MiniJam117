using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(TimerOfGameObject))]
public class WarriorFactory : GenericFactory<Warrior>,IEnemyFactory
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector2 _additionalTime = new Vector2(5,10);
    private EnemyCreator _enemyCreator;
    [SerializeField] private TimerOfGameObject _timerOfGameObject;
    public event Action<Enemy> OnCreateEnemy;
    private void OnEnable() 
    {
         _enemyCreator = new EnemyCreator();
         _timerOfGameObject.SetTimer(_enemyCreator.GetRandomTime(_additionalTime),TryCreating);
    }
    private void TryCreating() => OnCreateEnemy?.Invoke(InstantiateObject(_enemyCreator.RandomCircle(_player.transform.position)));


}
