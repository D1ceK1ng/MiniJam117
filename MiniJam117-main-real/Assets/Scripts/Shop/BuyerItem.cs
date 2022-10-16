using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BuyerItem : MonoBehaviour
{
   public event Action<Item> OnBuy;
   public void BuyItem(Item item)
   {
    OnBuy?.Invoke(item);
   }
}
