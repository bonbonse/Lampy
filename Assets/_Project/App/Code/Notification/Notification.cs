using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField]
    GameObject window;
    [SerializeField]
    TMP_Text message;
    [SerializeField]
    TMP_Text buttonText;

    public void SendNotification(string message, string buttonText = "Îê")
    {
        window.SetActive(true);
        this.message.text = message;
        this.buttonText.text = buttonText;
    }
}
