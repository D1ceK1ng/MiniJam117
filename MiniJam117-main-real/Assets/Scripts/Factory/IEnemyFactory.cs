using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IEnemyFactory 
{
    public event Action<Enemy> OnCreateEnemy;
}
