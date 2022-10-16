using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorBullet : GenericFactory<Bullet>
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Vector2 _bordersForRandomAngle = new Vector2(-10,10);
    public void CreateBullet(Vector2 distance)
    {
     float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
     angle += Random.Range(_bordersForRandomAngle.x,_bordersForRandomAngle.y);
     Bullet bullet = InstantiateObject(_shootPoint.position);
     bullet.transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
