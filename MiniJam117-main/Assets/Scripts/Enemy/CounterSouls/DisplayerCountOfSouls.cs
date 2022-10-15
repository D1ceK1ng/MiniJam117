using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class DisplayerCountOfSouls : MonoBehaviour
{
    [SerializeField] private CounterSouls _counterSouls;
    [SerializeField] private Text _text;
    private int _countOfSouls;
    private void Awake() 
    {
        _counterSouls.OnKillEnemy += AddDeadSoul;
    }
    private void AddDeadSoul()
    {
        _countOfSouls++;
        _text.text = $"KILLED SOULS: {_countOfSouls}";
    }
    private void OnDisable()
    {
        _counterSouls.OnKillEnemy -= AddDeadSoul;
    }
}
