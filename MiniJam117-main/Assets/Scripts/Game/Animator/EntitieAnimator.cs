using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitieAnimator : IStoppable
{
    private Animator _animator;
   public EntitieAnimator(Animator animator)
   {
    _animator = animator;
    Pause.AddEntitie(this);
   }
    public void StopEntitie()
    {
        _animator.enabled = false;
    }

    public void PlayEntitie()
    {
        _animator.enabled = true;
    }
}
