using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealPlayerStat", menuName = "ScriptableObjects/PlayerStat/HealPlayerStat", order = 1)]
public class HealPlayerStat : PlayerStat
{
   [SerializeField] private float _additionalProcentOf;

}
