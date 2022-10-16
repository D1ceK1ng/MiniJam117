using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamagableAbility", menuName = "ScriptableObjects/Ability/DamagableAbility", order = 1)]
public class DamagableAbility : Ability
{
    [SerializeField] private float _procentOfAdditonalDamage = 1.1f;

    public override TypeOfStat CurrentTypeOfStat { get; set ; } = TypeOfStat.Damagable;
    public float ProcentOfAdditonalDamage { get => _procentOfAdditonalDamage; set => _procentOfAdditonalDamage = value; }
}
