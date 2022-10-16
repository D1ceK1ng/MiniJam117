using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ImprovementStats : MonoBehaviour
{
   [SerializeField] private TypeOfStat _typeOfStat;
  [SerializeField] private LoaderAbilities _loaderAbilities;
    [SerializeField] private Transform _spawnPoint;
   [SerializeField] private SlotImpovement _slotImpovement;
   private List<SlotImpovement> _listOfSlotImpovement = new List<SlotImpovement>();
   public event Action<Ability> OnBuyAbility;
   private void Start() 
   {
    Ability  currentAbility = _loaderAbilities.LoadedAbilities.Find(e=>e.CurrentTypeOfStat == _typeOfStat);
     foreach (var item in _loaderAbilities.AllAbilities.FindAll(e=>e.CurrentTypeOfStat == _typeOfStat))
     {
        SlotImpovement slotImpovement = Instantiate(_slotImpovement, _spawnPoint.position ,Quaternion.identity);
        slotImpovement.Ability = item;
        slotImpovement.OnBuy += TrySetNewAvableSlot;
        slotImpovement.transform.SetParent(_spawnPoint);
        _listOfSlotImpovement.Add(slotImpovement);
     }
     List<SlotImpovement> slotImpovements = _listOfSlotImpovement.TakeWhile(e=>e.Ability.Price <= currentAbility.Price).ToList();
     slotImpovements.ForEach(e=>e.MakeSlotInStock());
     if(slotImpovements.Count != _listOfSlotImpovement.Count)
     {
     _listOfSlotImpovement.Find(e=>e.Ability == currentAbility)?.SetAvableSlot();
     }
     if (slotImpovements.Count == 0)
     {
       _listOfSlotImpovement.FirstOrDefault().SetAvableSlot();
     }
   }
   private void TrySetNewAvableSlot(SlotImpovement slotImpovement)
   {
      Debug.Log("BUUY!");
      OnBuyAbility?.Invoke(slotImpovement.Ability);
      int countOfNextSlot = _listOfSlotImpovement.IndexOf(slotImpovement) + 1;
      if(_listOfSlotImpovement.Count > countOfNextSlot)
      {
       _listOfSlotImpovement[countOfNextSlot].SetAvableSlot();
      }
   }
   private void OnDisable() 
   {
      _listOfSlotImpovement.ForEach(e=>e.OnBuy -= TrySetNewAvableSlot);
   }
}
