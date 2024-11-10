using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Human
{
    public class Human : MonoBehaviour
    {
        public string fullname = "Работник";

        private void Start()
        {
            GetComponentInChildren<TMP_Text>().text = fullname;
        }
    }
}

