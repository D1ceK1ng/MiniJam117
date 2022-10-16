using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaverItems : MonoBehaviour
{
  [SerializeField] private CollectorOfItems _collectorOfItems;
  private void Awake() 
  {
    _collectorOfItems.OnAddItem += SaveItem;
  }
  private void SaveItem()
  {
    Saver<SavabelItems>.Save(new SavabelItems(_collectorOfItems.Items.Select(e=>e.Name).ToList()));
  }
  private void OnDisable() 
  {
     _collectorOfItems.OnAddItem -= SaveItem;
  }
}
