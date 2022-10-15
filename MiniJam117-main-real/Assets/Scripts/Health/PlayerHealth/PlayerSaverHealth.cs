using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaverHealth : MonoBehaviour
{
   [SerializeField] private PlayerHealth _playerHealth;
   private void Awake() 
   {
        _playerHealth.OnChangeHealth += Save;
   }
   public void Save()
   {
    Saver<SavableHealth>.Save(new SavableHealth(_playerHealth.CurrentHealth));
   }
   private void OnDisable() 
   {
     _playerHealth.OnChangeHealth -= Save;
   }
}
