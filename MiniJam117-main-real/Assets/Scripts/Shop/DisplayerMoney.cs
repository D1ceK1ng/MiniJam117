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
    _wallet.OnChangeCountOfMoney += DisplayMoney;
  }
  private void Start() 
  {
    DisplayMoney();
  }
  private void DisplayMoney()
  {
    _text.text = _wallet.CountOfMoney.ToString();
  }
  private void OnDisable() 
  {
     _wallet.OnChangeCountOfMoney -= DisplayMoney;
  }
}
