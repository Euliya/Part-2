using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    bool inHole;
    float score = 0;
    Collider2D hole;

    // Start is called before the first frame update
    void Start()
    {
        hole = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hole.OverlapPoint(collision.gameObject.transform.position))
        {
            collision.gameObject.GetComponent<Mouse>().inHole = true;
            inHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inHole == true)
        {
            score++;
            Debug.Log(score);
            inHole = false;
        }
    }
}
