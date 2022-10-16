using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class CollectorOfItems : MonoBehaviour
{
   [SerializeField] private BuyerItem _buyerItem;
   [SerializeField] private List<Item> _allItems;
   private List<Item> _items = new List<Item>();
   public List<Item> Items => _items;
   public List<Item> AllItems => _allItems;
   public event Action OnAddItem;
    private void Awake() 
   {
    SavabelItems savabelItems = Loader<SavabelItems>.Load(new SavabelItems());
    if (savabelItems != null)
    {
        savabelItems.NamesOfItems.ForEach(e=>_items.Add(_allItems.Find(a=>a.Name == e)));
    }
    _buyerItem.OnBuy += AddItem;
   }
   private void AddItem(Item item)
   {
    _items.Add(item);
    OnAddItem?.Invoke();
   }
   private void OnDisable() 
   {
     _buyerItem.OnBuy -= AddItem;
   }
}
