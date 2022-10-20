using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour, IStoppable
{
    private protected bool _canBeStopped = true;
    private void OnEnable() {
        Pause.AddEntitie(this);
    }
    public void StopEntitie()
    {
        _canBeStopped = false;
    }
    public void PlayEntitie()
    {
        _canBeStopped = true;
    }
}
