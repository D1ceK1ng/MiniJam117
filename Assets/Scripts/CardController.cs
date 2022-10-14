using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Collider2D _collider;

    public bool IsMouseOver;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        IsMouseOver = true;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
