using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HealingAbility", menuName = "ScriptableObjects/Ability/HealingAbility", order = 1)]
public class HealingAbility : Ability
{
   [SerializeField] private float _procentOfAdditonalHealth = 1.1f;
    public override TypeOfStat CurrentTypeOfStat { get; set ; } = TypeOfStat.Healing;
    public float ProcentOfAdditonalHealth { get => _procentOfAdditonalHealth; set => _procentOfAdditonalHealth = value; }
}
