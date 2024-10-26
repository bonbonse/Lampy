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
                "�� ��������� ������! ��� �������!\n " +
                "��� ���������� ������� ����� ������, ������� ������� �� ����� �������� ���!"
                );

        }
    }
}
