using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void Catched(float oneMouse)
    {
        slider.value -= oneMouse;
    }
}
