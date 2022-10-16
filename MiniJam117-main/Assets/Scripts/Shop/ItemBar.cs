using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    private Item _item;
   [SerializeField] private Text _text;
   public Item Item { get => _item; set => _item = value; }
   public void ShowText(int countOfItems)
   {
    _text.text = $"You have {countOfItems} {Item.Name}";
   }
}
