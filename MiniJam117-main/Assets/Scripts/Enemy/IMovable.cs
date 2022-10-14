using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public float Speed { get; set; }
    public Transform CurrentTransform {get;set;}
    public void Move();
}
