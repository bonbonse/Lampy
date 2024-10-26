using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public string curTimeStr = "";
    public Notification notification;
    
    private int curTime = 32350;
    void Start()
    {
        StartCoroutine(MainTimer());
        if (notification == null)
        {
            notification = FindObjectOfType<Notification>();
        }
    }

    IEnumerator MainTimer()
    {
        curTimeStr = TimeSpan.FromSeconds(curTime).ToString(@"hh\:mm");
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
                Debug.Log("������ �������� ���");
                notification.SendNotification("������ �������� ���");
                break;
            case "17:00":
                Debug.Log("�����");
                notification.SendNotification("����� �������� ���");
                break;

        }
    }
}
