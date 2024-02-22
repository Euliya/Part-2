using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootbalPlayer : MonoBehaviour
{
    Color baseColor;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseColor=spriteRenderer.color;
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Selected(true);
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

}
