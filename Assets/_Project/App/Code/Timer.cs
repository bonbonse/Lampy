using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float curTime = 32350;
    public string curTimeStr = "";
    public Notification notification;
    void Start()
    {
        StartCoroutine(MainTimer());
    }

    IEnumerator MainTimer()
    {
        curTimeStr = TimeSpan.FromSeconds(curTime).ToString(@"hh\:mm");
        yield return new WaitForSeconds(0.5f);
        curTime += 60;
        CheckNotification();
        StartCoroutine(MainTimer());
    }
    // Проверка уведомлений по времени
    public void CheckNotification()
    {
        switch (curTimeStr)
        {
            case "09:00":
                Debug.Log("Начало рабочего дня");
                
                break;
            case "17:00":
                Debug.Log("Конец");
                break;

        }
    }
}
