using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class DisplayerCountOfSouls : MonoBehaviour
{
    [SerializeField] private CounterSouls _counterSouls;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Text _text;
    private int _countOfSouls;
    private void Awake() 
    {
        _counterSouls.OnKillEnemy += AddDeadSoul;
    }
    private void Start() 
    {
        ShowText();
    }
    private void AddDeadSoul()
    {
        _wallet.IncreaseCountOfMoney(1);
        ShowText();
    }
    public void ShowText() =>  _text.text = $"Souls collected: {_wallet.CountOfSouls}";
    private void OnDisable()
    {
        _counterSouls.OnKillEnemy -= AddDeadSoul;
    }
}
