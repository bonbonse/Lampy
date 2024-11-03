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
    // �������� ����������� �� �������
    public void CheckNotification()
    {
        switch (curTimeStr)
        {
            case "09:00":
                Notification.SendNotification(
                    "������ �������� ���. ���� �������� ��� �������� ������." +
                    "������� �� �� �����, ��� � ��� ������ ������. ������ ������� ������� �������." +
                    "WASD - ����������, E - �������������� � ���������� ����������." +
                    "�������, �� ����� �� ���� ������ � ���� �� ������... �� ���������������!");
                break;
            case "14:00":
                Notification.SendNotification("����. �� ����� ���� ����� ������ (��������)");
                break;
            case "17:00":
                Notification.SendNotification(
                    "����� �������� ���." +
                    "� ��� �� ������� ������� �� ������ � ������ ��� ����������." +
                    "�� ��� ��� �� ������� �������, ���� ����� �� ����� ������� - �� ��� ����� ������������!" +
                    "���������� �������� ���� ������ �� ���� ����:)",
                    "�����",
                    true
                );
                break;

        }
    }
}
