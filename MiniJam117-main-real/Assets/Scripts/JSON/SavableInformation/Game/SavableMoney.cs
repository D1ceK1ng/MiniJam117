using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableMoney : ISavable
{
  public string CountOfMoney;
  public SavableMoney(string countOfMoney)
  {
    CountOfMoney = countOfMoney;
  }
  public SavableMoney()
  {
    
  }
}
