using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayerMoney : MonoBehaviour
{
  [SerializeField] private Wallet _wallet;
  [SerializeField] private Text _text;
  private void Awake() 
  {
    _wallet.OnChangeCountOfSouls += DisplayMoney;
  }
  private void Start() 
  {
    DisplayMoney();
  }
  private void DisplayMoney()
  {
    _text.text = _wallet.CountOfSouls.ToString();
  }
  private void OnDisable() 
  {
     _wallet.OnChangeCountOfSouls -= DisplayMoney;
  }
}
