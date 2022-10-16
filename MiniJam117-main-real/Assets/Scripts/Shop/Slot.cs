using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
   [SerializeField] private Item _item;
   private BuyerItem _buyerItem;
   private Wallet _wallet;
   [SerializeField] private Text _nameOfItem;
   [SerializeField] private Text _textOfPriceOfItem;
   private void Awake() 
   {
    _buyerItem = FindObjectOfType<BuyerItem>();
    _wallet = FindObjectOfType<Wallet>();
    _nameOfItem.text = _item.Name;
    _textOfPriceOfItem.text = _item.Price.ToString();
   }
   public void OnClick()
   {
    if(_wallet.CountOfMoney - _item.Price >= 0)
    {
     _buyerItem.BuyItem(_item);
    }
   }
}
