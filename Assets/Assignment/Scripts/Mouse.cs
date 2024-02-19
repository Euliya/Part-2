using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Mouse : MonoBehaviour
{
    Vector2 place;
    Vector2 movement;
    public float speed = 5f;
    Rigidbody2D rb;
    float shrink;
    public AnimationCurve inHoleA;
    public AnimationCurve catchA;
    public bool inHole;
    public bool catched;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            place = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (inHole == true)
        {
            shrink += 1f * Time.deltaTime;
            float interpolation = inHoleA.Evaluate(shrink);

            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }
    }
    private void FixedUpdate()
    {
        movement=place - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

        if (catched == true)
        {
            speed = 0f;
            shrink += 1f * Time.deltaTime;
            float interpolation = catchA.Evaluate(shrink);

            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        catched = true;
    }

   
}