using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   
    public void sixbynight()
    {
        Screen.SetResolution(1600,900, false);
    }

    public void fullscreen()
    {
        Screen.SetResolution(1920,1080,false);
    }
}
