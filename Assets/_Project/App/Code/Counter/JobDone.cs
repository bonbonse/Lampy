using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobDone : Counter
{
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
    }
}
