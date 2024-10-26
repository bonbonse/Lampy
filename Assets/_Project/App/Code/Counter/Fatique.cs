using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fatique : Counter
{
    public float sec = 4;
    public TMP_Text fatiqueText; // вынести в counter
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
        fatiqueText.text = curValue.ToString();
        if (curValue <= maxValue)
        {
            notification.SendNotification(
                "Переутомление! У вас отказывает сердце:(" +
                "Бос недоволен вашей слабостью. На этом ваш рабочий день закончен!"
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
