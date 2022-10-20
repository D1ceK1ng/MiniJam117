using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerRotation : MonoBehaviour, IStoppable
{
    private Animator _animator;
    private bool _canMove = true;
    private EntitieAnimator _entitieAnimator;
    private void Start()
    {
        Pause.AddEntitie(this);
        _animator = GetComponent<Animator>();
        _entitieAnimator = new EntitieAnimator(_animator);
    }

    private void Update() 
    {
        if(_canMove)
        {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        _animator.SetFloat("MousePositionX",direction.x );
        }
    }
    public void StopEntitie()
    {
        _canMove = false;
    }


    public void PlayEntitie()
    {
        _canMove = true;
    }
    private void OnDisable() {
       Pause.RemoveEntitie(_entitieAnimator);
    }
}
