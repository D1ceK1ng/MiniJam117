using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StarterNewGame : MonoBehaviour
{
    public static void StartNewGame()
    {
        Saver<SavableSelectedCharacter>.Save(new SavableSelectedCharacter(""));
        Saver<SavableInterface>.Save(new SavableInterface(new List<string>()));
        Saver<SavablePassedDoors>.Save(new SavablePassedDoors(new List<string>()));

        Saver<SavableHealth>.Save(new SavableHealth());
        Saver<SavableMusicSettings>.Save(new SavableMusicSettings());
    }
    public void TryStartNewGame()
    {
       SavableHealth savableHealth = Loader<SavableHealth>.Load(new SavableHealth());
       if (savableHealth != null)
       {
         if (savableHealth.Health != "")
         {
            int health = int.Parse(savableHealth.Health);
            if (health <= 0)
            {
                StartNewGame();
            }
         }
       }
    }
}
