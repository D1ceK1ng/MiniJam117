using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable : IStoppable
{
    public float Speed { get; set; }
    public bool CanMove { get; set; }
    public Transform CurrentTransform {get;set;}
    public void Move();
}
