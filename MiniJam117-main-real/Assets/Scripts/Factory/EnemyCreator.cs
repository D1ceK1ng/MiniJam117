using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator
{
    private float _radius = 10;
    public float GetRandomTime(Vector2 additionalTime)
    {
        return Random.Range(additionalTime.x, additionalTime.y);
    }
    public Vector3 RandomCircle (Vector3 center)
    {
         float angle = Random.value * 360;
         return new Vector3(center.x + _radius * Mathf.Sin(angle * Mathf.Deg2Rad),center.y + _radius * Mathf.Cos(angle * Mathf.Deg2Rad),center.z);
    }
}
