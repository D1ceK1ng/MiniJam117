using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Wallet : MonoBehaviour
{
   [SerializeField] private BuyerItem _buyerItem;
   [SerializeField] private int _countOfMoney;
   public int CountOfMoney => _countOfMoney;
   public event Action OnChangeCountOfMoney;
   private void Awake() 
   {
    SavableMoney savableMoney = Loader<SavableMoney>.Load(new SavableMoney());
    if (savableMoney != null)
    {
        _countOfMoney = int.Parse(savableMoney.CountOfMoney);
    }
    _buyerItem.OnBuy += DecreaseCountMoney;
   }
   private void DecreaseCountMoney(Item item)
   {
    _countOfMoney -= item.Price;
    OnChangeCountOfMoney?.Invoke();
   }
   public void IncreaseCountOfMoney(int countOfAdditionalMoney)
   {
    _countOfMoney += countOfAdditionalMoney;
    OnChangeCountOfMoney?.Invoke();
   }
}
