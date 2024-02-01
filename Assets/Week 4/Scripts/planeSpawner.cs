using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class planeSpawner : MonoBehaviour
{
    public GameObject planeprefab;
    float timervalue;
    float timertarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timervalue += Time.deltaTime;
        if(timervalue >timertarget)
        {
            Instantiate(planeprefab);
            timervalue = 0;
            timertarget=Random.Range(1,5);
        }
    }
}
