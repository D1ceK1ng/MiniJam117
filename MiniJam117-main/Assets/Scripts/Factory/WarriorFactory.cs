using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorFactory : GenericFactory<Warrior>
{
    [SerializeField] private Player _player;
    [SerializeField] private float _radius = 5; 
    [SerializeField] private Vector2 _additionalTime = new Vector2(5,10);
    private void Awake() 
    {
         StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        InstantiateObject(RandomCircle(_player.transform.position, _radius));
        float randomTime = Random.Range(_additionalTime.x,_additionalTime.y);
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(CoolDown());
    }
    private Vector3 RandomCircle (Vector3 center, float radius)
    {
         float angle = Random.value * 360;
         return new Vector3(center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad),center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad),center.z);
     }

}
