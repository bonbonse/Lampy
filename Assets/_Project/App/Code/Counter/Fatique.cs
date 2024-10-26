using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatique : Counter
{
    void Awake()
    {
        maxValue = 0;
        curValue = 100;
    }
    public override void AddProgress(float value)
    {
        base.AddProgress(value);
        if (curValue <= maxValue)
        {
            notification.SendMessage(
                "Переутомление! У вас отказывает сердце:(" +
                "Бос недоволен вашей слабостью. На этом ваш рабочий день закончен!"
                );

        }
    }
}
