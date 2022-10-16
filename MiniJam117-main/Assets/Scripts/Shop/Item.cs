using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    public int Price => _price; 
    public string Name => _name;
}
