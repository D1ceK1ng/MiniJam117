using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CardObject;

    public CardController CardController;


    private float _deltaSpeed = 5;
    private float _damping = 10;
    private float _rotationDistance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && CardController.IsMouseOver)
        {
            Vector2 screenToWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CardObject.transform.position = screenToWorldPoint;
        }
        else
        {
            CardObject.transform.position =
                Vector2.MoveTowards(CardObject.transform.position, Vector2.zero, _deltaSpeed);
        }


        float dampingTime = _damping * Time.deltaTime;
        if (CardObject.transform.position.x > _rotationDistance)
        {
            CardObject.transform.localRotation = Quaternion.Lerp(CardObject.transform.rotation,Quaternion.Euler(0,0,-30),dampingTime );
        }
        else if (CardObject.transform.position.x < -_rotationDistance)
        {
            CardObject.transform.localRotation = Quaternion.Lerp(CardObject.transform.rotation, Quaternion.Euler(0, 0, 30), dampingTime);
        }
        else
        {
            CardObject.transform.localRotation = Quaternion.Lerp(CardObject.transform.rotation, Quaternion.Euler(0, 0, 0), dampingTime);
        }
    }
}



