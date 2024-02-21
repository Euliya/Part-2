using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public TextMeshProUGUI score;
    float scoreIndex = 0;
 
    // Update is called once per frame
    void Update()
    {
        scoreIndex += Time.deltaTime;
        score.text = scoreIndex.ToString("00");
    }
}
