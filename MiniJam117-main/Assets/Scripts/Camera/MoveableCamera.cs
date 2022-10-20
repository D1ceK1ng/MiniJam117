using UnityEngine;
public class MoveableCamera : MonoBehaviour
{
     private Player _player;
    [SerializeField] private float _speed = 5;
     private Vector2 _velocity;
     [SerializeField] private float _leftLimit = -100;
    [SerializeField] private float _rightLimit = 100;
     [SerializeField] private float _bottomLimit = -100;
     [SerializeField] private float _upperLimit =100;
    private void Start() 
    {
     _player = FindObjectOfType<Player>();
    }    
   private void Update()
    {

         transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit), 
             Mathf.Clamp(transform.position.y, _bottomLimit, _upperLimit), 
             transform.position.z
        );
    }
   private void FixedUpdate()
    {

        transform.position = new Vector3
        (GetPlayerPosiotion(transform.position.x, _player.transform.position.x,_velocity.x),
         GetPlayerPosiotion(transform.position.y, _player.transform.position.y,_velocity.y),
        transform.position.z);
    }
    private float GetPlayerPosiotion(float position,float playerPositon, float velocity) =>  Mathf.SmoothDamp(position, playerPositon, ref velocity, _speed); 
}
