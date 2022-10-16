using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdaterCountOfSouls : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private DisplayerCountOfSouls _displayerCountOfSouls;
    private void Awake() 
    {
        _wallet.OnChangeCountOfSouls += UpdateCountOfSouls;
    }
    private void UpdateCountOfSouls()
    {
        _displayerCountOfSouls.ShowText();
    }
    private void OnDisable() 
    {
         _wallet.OnChangeCountOfSouls -= UpdateCountOfSouls;
    }
}
