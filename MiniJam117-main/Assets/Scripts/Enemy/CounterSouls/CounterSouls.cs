using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CounterSouls : MonoBehaviour
{
    private List<IEnemyFactory> _enemyFactories = new List<IEnemyFactory>();
    public event Action OnKillEnemy;
    private void Awake() 
    {
        _enemyFactories.Add(FindObjectOfType<WarriorFactory>());
        _enemyFactories.Add(FindObjectOfType<RangerFactory>());
        _enemyFactories.ForEach(e=>e.OnCreateEnemy += AddEnemy);
    }
    private void AddEnemy(Enemy enemy)
    {
        enemy.Health.OnDestroy += RemoveEnemy;
    }
    private void RemoveEnemy(Health health)
    {
        OnKillEnemy?.Invoke();
        health.OnDestroy -= RemoveEnemy;
    }
    private void OnDisable() 
    {
          _enemyFactories.ForEach(e=>e.OnCreateEnemy -= AddEnemy);
    }
}
