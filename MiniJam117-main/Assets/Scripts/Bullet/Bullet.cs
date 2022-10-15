using UnityEngine;

public class Bullet : MonoBehaviour
{
    

    void Update()
    {
        Destroy(gameObject,.6f);
    }

    void OnColliderEnter(Collider2D collider2D)
    {
        Destroy(gameObject);
    }
}
