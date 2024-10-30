using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fatique : Counter
{
    public float sec = 4;
    public TMP_Text fatiqueText; // ������� � counter
    void Awake()
    {
        maxValue = 0;
        curValue = 100;
    }
    private void Start()
    {
        StartCoroutine(FatiqueProgress());
    }
    public override void AddProgress(float value)
    {
        base.AddProgress(value);
        if (curValue > 100)
            curValue = 100;
        fatiqueText.text = curValue.ToString();
        if (curValue <= maxValue)
        {
            Notification.SendNotification(
                "�������������! � ��� ���������� ������:(" +
                "��� ��������� ����� ���������. �� ���� ��� ������� ���� ��������!"
                );

        }
    }
    IEnumerator FatiqueProgress()
    {
        fatiqueText.text = curValue.ToString();
        yield return new WaitForSeconds(sec);
        AddProgress(-1);
        StartCoroutine(FatiqueProgress());
    }
}
