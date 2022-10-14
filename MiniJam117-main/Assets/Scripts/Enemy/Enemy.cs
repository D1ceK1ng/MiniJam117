using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private protected float _speed = 1;
    protected IMovable _iMovable;
    public abstract IMovable IMovable {get;}
    public abstract float Speed {get;set;}
    private void Update() 
    {
        IMovable.Move();
    }
}
