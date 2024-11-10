using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Windows : MonoBehaviour
{
    public GameObject notification;
    public TMP_Text notificationText;
    public GameObject notificationButton;
    public TMP_Text canClickE;

    public void ShowClickE()
    {
        canClickE.gameObject.SetActive(true);
    }
    public void UnShowClickE()
    {
        canClickE.gameObject.SetActive(false);
    }
}
