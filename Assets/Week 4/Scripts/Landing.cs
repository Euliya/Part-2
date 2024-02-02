using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Landing : MonoBehaviour
{
    
    float score = 0;
    public GameObject planeprefab;
    bool plane;
    Collider2D landing;
    

    // Start is called before the first frame update
    void Start()
    {
        landing = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
               
        if (landing.OverlapPoint(collision.gameObject.transform.position))
        {
            collision.gameObject.GetComponent<Plane>().plane = true;
            plane = true;
        }
        
      
    }
    void OnTriggerEnter2D (Collider2D collision)
    {
        if (plane == true)
        {
            score++;
            Debug.Log(score);
            plane = false;
        }
    }
}
