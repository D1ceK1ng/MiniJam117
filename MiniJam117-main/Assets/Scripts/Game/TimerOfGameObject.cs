using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimerOfGameObject : MonoBehaviour, IStoppable
{
  private bool _isTimeGoing = true;
  private float _currentTime;
  private float _waitTime;
  private Action OnAction;
  private void Awake() 
  {
     Pause.AddEntitie(this);
  }
  public void SetTimer(float waitTime, Action action)
  {
    _waitTime = waitTime;
    OnAction = action;
  }
  private void Update() 
  {
    if (_isTimeGoing)
    {
        _currentTime+= Time.deltaTime;
        if (_currentTime >= _waitTime)
        {
            OnAction.Invoke();
            _currentTime = 0;
        }
    }
  }
  public void StopEntitie()
  {
        _isTimeGoing = false;
  }

   public void PlayEntitie()
   {
      _isTimeGoing = true;
   }
}
