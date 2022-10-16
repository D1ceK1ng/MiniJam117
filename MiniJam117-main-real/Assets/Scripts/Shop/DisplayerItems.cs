using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class DisplayerItems : MonoBehaviour
{
    [SerializeField] private ItemBar _itemBar;
    [SerializeField] private Transform _point;
    [SerializeField] private BuyerItem _buyerItem;
    [SerializeField] private CollectorOfItems _collectorOfItems;
    private List<ItemBar> _itemBars = new List<ItemBar>();
   public void ShowText(ItemBar itemBar, Item item)
   {
       itemBar.ShowText(_collectorOfItems.Items.FindAll(e=>e.Name == item.Name).Count);
   }
   private void Start() 
   {
      foreach (var item in _collectorOfItems.AllItems)
    {
       ItemBar itemBar = Instantiate(_itemBar,_point.position,Quaternion.identity);
       itemBar.Item = item;
       itemBar.transform.SetParent(_point);
       ShowText(itemBar, item);
       _itemBars.Add(itemBar);
    }
     _buyerItem.OnBuy += Display;
   }
   private void Display(Item item)
   {
     ItemBar itemBar = _itemBars.Find(e=>e.Item.Name == item.Name);
     ShowText(itemBar, item);
   }
   private void OnDisable() 
   {
     _buyerItem.OnBuy -= Display;
   }
}
