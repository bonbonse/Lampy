using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOk : MonoBehaviour
{
    public void ButtonClick()
    {
        if (Notification.text.Count == 0)
        {
            if (App.isEnd)
            {
                Exit();
            }
            CloseWindow();
        }
        else
        {
            NextMessage();
        }
    }
    protected void CloseWindow()
    {
        App._app.windows.notification.SetActive(false);
    }
    protected void NextMessage()
    {
        Notification.NextMessage();
    }
    protected void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
