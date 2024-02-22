using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;

public class GoalkeeperController : MonoBehaviour
{
    public Transform center;
    Vector2 position;
    Vector2 Distance;
    public Rigidbody2D rb;
    FootbalPlayer SelectedPlayer;
    float speed = 2;

    // Update is called once per frame
    void FixedUpdate()
    {
        SelectedPlayer = Controller.SelectedPlayer;
        if (SelectedPlayer == null) return;
        Distance = SelectedPlayer.transform.position - center.position;

        if (Distance.magnitude <= 3)
        {
            position = (center.position + SelectedPlayer.transform.position) / 2;
        }
        else
        {
            position = (Vector2)center.position + Distance.normalized * 3;
        }
        rb.MovePosition(Vector2.MoveTowards(rb.transform.position,position,speed*Time.deltaTime));


    }
}
