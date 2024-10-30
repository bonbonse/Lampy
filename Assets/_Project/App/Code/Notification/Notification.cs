using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    private static GameObject _window;
    private static TMP_Text _message;
    private static Button _button;
    private static TMP_Text _buttonText;

    public static void Init(GameObject window, TMP_Text message, GameObject button)
    {
        _window = window;
        _message = message;
        _button = button.GetComponent<Button>();
        _buttonText = button.GetComponentInChildren<TMP_Text>();
    }

    public static void SendNotification(string message, string buttonText = "Îê", bool isEnd = false, Sprite image = null)
    {
        _window.SetActive(true);
        _message.text = message;
        _buttonText.text = buttonText;
        if (isEnd)
        {
            Time.timeScale = 0;
            _button.onClick.AddListener(Out);
        }
    }
    private static void Out()
    {
        SceneManager.LoadScene("Menu");
    }
}
