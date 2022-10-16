using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Ability : ScriptableObject
{
    [SerializeField] private int _price = 2;
    public abstract TypeOfStat CurrentTypeOfStat {get;set;}
    public int Price { get => _price; set => _price = value; }
}
