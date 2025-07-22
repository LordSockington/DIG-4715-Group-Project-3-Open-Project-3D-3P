using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    //Sets Variables
    [SerializeField] TextMeshProGUI timerText;
    [SerializeField] float timeLeft;

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft < 0)
        {
            timeLeft = 0;
            //Add game over function here
            timerText.color = color.red;
        }
        int minutes = Mathf.FlooToInt(timeLeft / 60);
        int seconds = Mathf.FlooToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
