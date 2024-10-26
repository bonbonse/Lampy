using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JobDone : Counter
{
    public TMP_Text jobDoneText;
    public App app;
    void Awake()
    {
        maxValue = 100; 
        curValue = 0;
    }
    public override void AddProgress(float value)
    {
        base.AddProgress(value);
        if (curValue >= maxValue)
        {
            notification.SendMessage(
                "Вы выполнили задачу! Бос доволен!\n " +
                "Вам поручается сделать новую задачу, успейте сделать до конца рабочего дня!"
                );

        }
        jobDoneText.text = curValue.ToString();
    }
    public void TaskOn()
    {
        app.task.SetActive(true);
    }
    public void TaskOff()
    {
        app.task.SetActive(false);
    }
}
