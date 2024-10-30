using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour 
{
    public Notification notification;
    public Timer timer;
    public Fatique fatique;
    public JobDone jobDone;
    public GameObject task;
    public Player.Player player;
    public Boss.Boss boss;
    public Windows windows;

    private void Awake()
    {
        Notification.Init(windows.notification, windows.notificationText, windows.notificationButton);
    }
}
