using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    bool isPlayerAlive = true;

    void Update()
    {
        if (isPlayerAlive)
        {
            StartTimer();
        }
    }

    public void StartTimer()
    {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isPlayerAlive = false;
    }
}
