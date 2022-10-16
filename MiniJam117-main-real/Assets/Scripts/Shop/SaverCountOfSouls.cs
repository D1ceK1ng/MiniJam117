using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverCountOfSouls : MonoBehaviour
{
  [SerializeField] private Wallet _wallet;
   private void Awake() 
   {
     _wallet.OnChangeCountOfSouls += SaveMoney;
   }
   public void SaveMoney()
   {
    Saver<SavableCountOfSouls>.Save(new SavableCountOfSouls(_wallet.CountOfSouls.ToString()));
   }
   private void OnDisable() 
   {
      _wallet.OnChangeCountOfSouls -= SaveMoney;
   }
}
