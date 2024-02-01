using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;
    public float speed = 1;
    public AnimationCurve landing;
    float timerValue;
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position+ new Vector3(Random.Range(-5,5), Random.Range(-5, 5)));
        GetComponent<Transform>().rotation= Quaternion.Euler(0, 0, Random.Range(0, 360));
        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0,4)];
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = Random.Range(1, 3);
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);

            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0 )
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            } 
        }
        if (transform.position.x> 16.5||transform.position.x<-16.5|| transform.position.y>7|| transform.position.y<-7)
        {
            Destroy(gameObject);
        }

    }
    private void OnMouseDown()
    {
        points= new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
    private void OnMouseDrag()
    {
        Vector2 newPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
       spriteRenderer.color = Color.white;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(Vector3.Distance(transform.position, collision.gameObject.transform.position)<1)
        {
            Destroy(gameObject);
        }
    }
}
