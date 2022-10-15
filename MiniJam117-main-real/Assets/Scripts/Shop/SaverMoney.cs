using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverMoney : MonoBehaviour
{
  [SerializeField] private Wallet _wallet;
   private void Awake() 
   {
     _wallet.OnChangeCountOfMoney += SaveMoney;
   }
   private void SaveMoney()
   {
    Saver<SavableMoney>.Save(new SavableMoney(_wallet.CountOfMoney.ToString()));
   }
   private void OnDisable() 
   {
      _wallet.OnChangeCountOfMoney -= SaveMoney;
   }
}
