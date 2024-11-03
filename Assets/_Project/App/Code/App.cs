using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour 
{
    public Timer timer;
    public Fatique fatique;
    public JobDone jobDone;
    public GameObject task;
    public Player.Player player;
    public Boss.Boss boss;
    public Windows windows;

    public static bool isEnd = false;
    public static App _app;

    private void Awake()
    {
        isEnd = false;
        _app = this;

        Notification.Init(windows.notification, windows.notificationText, windows.notificationButton);
    }
}
