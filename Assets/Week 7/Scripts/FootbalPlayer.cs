using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootbalPlayer : MonoBehaviour
{
    Color baseColor;
    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public float speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor=spriteRenderer.color;
        Selected(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }
   
    public void Selected(bool selected)
    {
        if(selected)
        {
            spriteRenderer.color = Color.yellow;
        } else
        {
            spriteRenderer.color = baseColor;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction*speed);
    }

}
