using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Wallet : MonoBehaviour
{
   [SerializeField] private BuyerItem _buyerItem;
   [SerializeField] private int _countOfSouls;
   public int CountOfSouls => _countOfSouls;
   public event Action OnChangeCountOfSouls;
   private void Awake() 
   {
    SavableCountOfSouls savableCountOfSouls = Loader<SavableCountOfSouls>.Load(new SavableCountOfSouls());
    if (savableCountOfSouls != null)
    {
        if(savableCountOfSouls.CountOfSouls != "")
        {
        _countOfSouls = int.Parse(savableCountOfSouls.CountOfSouls);
        }
    }
    //_buyerItem.OnBuy += DecreaseCountMoney;
   }
   private void DecreaseCountMoney(Item item)
   {
    _countOfSouls -= item.Price;
    OnChangeCountOfSouls?.Invoke();
   }
   public void IncreaseCountOfMoney(int countOfAdditionalSoul)
   {
    _countOfSouls += countOfAdditionalSoul;
    OnChangeCountOfSouls?.Invoke();
   }
}
