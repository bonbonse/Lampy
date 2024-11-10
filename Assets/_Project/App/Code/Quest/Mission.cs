using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class Mission : ScriptableObject
    {
        public string from;
        public string to;
        public List<string> dialogs = new List<string>();
    }
}

