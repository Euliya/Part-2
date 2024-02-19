using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    Vector2 place;
    Vector2 movement;
    Rigidbody2D rb;
    public float speed=10f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("Horizontal", movement.normalized.x);
            animator.SetFloat("Vertical", movement.normalized.y);
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        
        if(movement.magnitude<0.5)
        {
            place = new Vector2(Random.Range(-6f, 8f), Random.Range(-4f, 5f));
        }
        
        movement = place - (Vector2)transform.position;
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

    }
}
