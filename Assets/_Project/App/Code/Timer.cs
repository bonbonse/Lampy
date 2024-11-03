using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public string curTimeStr = "";
    public TMP_Text timeText;
    
    private int curTime = 32350;
    void Start()
    {
        StartCoroutine(MainTimer());
    }

    IEnumerator MainTimer()
    {
        curTimeStr = TimeSpan.FromSeconds(curTime).ToString(@"hh\:mm");
        timeText.text = curTimeStr;
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
                Notification.SendNotification(
                    "Начало рабочего дня. Босс поручает вам доделать проект." +
                    "Надеюсь он не забыл, что у вас завтра отпуск. Проект придётся сделать сегодня." +
                    "WASD - управление, E - взаимодействие с некоторыми предметами." +
                    "Впрочем, вы давно на этой работе и сами всё знаете... Не перетруждайтесь!");
                break;
            case "14:00":
                Notification.SendNotification("Обед. На обеде босс более добрый (возможно)");
                break;
            case "17:00":
                Notification.SendNotification(
                    "Конец рабочего дня." +
                    "У вас не хватило времени на проект и попали под сокращение." +
                    "Но для нас вы большой молодец, если дошли до этого момента - мы вам очень признательны!" +
                    "Пожалуйста напишите ваше мнение об этой игре:)",
                    "Выйти",
                    true
                );
                break;

        }
    }
}
