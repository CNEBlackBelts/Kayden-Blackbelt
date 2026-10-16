using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timerText;

    void Update()
    {
        
        if (time <= 90)
        {
            time += Time.deltaTime;
            timerText.text = Mathf.Floor(time).ToString();

        }

    }




}
