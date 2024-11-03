using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Notification
{
    // фрагменты message
    public static Queue<string> text = new Queue<string>();

    private static int strLenght = 80;
    private static GameObject _window;
    private static TMP_Text _message;
    private static Button _button;
    private static TMP_Text _buttonText;
    private static bool isReadMessage = false;

    public static void Init(GameObject window, TMP_Text message, GameObject button)
    {
        _window = window;
        _message = message;
        _button = button.GetComponent<Button>();
        _buttonText = button.GetComponentInChildren<TMP_Text>();
    }

    public static void SendNotification(string message, string buttonText = "Ок", bool isEnd = false, Sprite image = null)
    {
        _window.SetActive(true);
        if (message.Length > strLenght)
        {
            SplitMessageOnStr(message);
            _buttonText.text = "дальше";
            _message.text = text.Dequeue();
        }
        else
        {
            _message.text = message;
            _buttonText.text = buttonText;
        }

    }
    // обрезает строку если она больше strLenght
    private static void SplitMessageOnStr(string message)
    {
        int i = 0;
        int messageSize = message.Length;
        while (messageSize > strLenght) 
        {
            if (messageSize >= strLenght)
            {
                text.Enqueue(message.Substring(i * strLenght, strLenght));
            }
            messageSize -= strLenght;
            i++;
        }
        text.Enqueue(message.Substring(i * strLenght, messageSize));
    }
    public static void NextMessage()
    {
        _message.text = text.Dequeue();
        if (text.Count == 0)
        {
            _buttonText.text = "ОК";
        }
    }
    private static void Out()
    {
        SceneManager.LoadScene("Menu");
    }
}
