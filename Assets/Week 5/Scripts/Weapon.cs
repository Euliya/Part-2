using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rigidbody;
    float count;
    float maxCount = 5000;

    // Start is called before the first frame update
    void Start()
    {
         rigidbody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position+(Vector2)transform.up*speed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (count == maxCount)
        {
            Destroy(gameObject);
        }
        else
        {
            count++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
    }

}

