using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class QuestManager : MonoBehaviour
    {
        public static AudioSource audioSource;
        public AudioClip[] musicClips; // Массив аудиофайлов

        private static List<Quest> quests;
        private static int activeQuestCount;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public static void Init()
        {
            quests = new List<Quest>();
            activeQuestCount = 0;
        }

        public static void CompleteQuest(string questName)
        {
            Quest quest = quests.Find(q => q.name == questName);
            if (quest != null)
            {
                PlayComletedMusic();
                quest.CompleteQuest();
                quests.Remove(quest);
                Debug.Log($"Квест {questName} завершён!");
            }
        }

        public static void AddQuest()
        {
            string questName = GetDefaultName();
            quests.Add(new Quest(questName));
            activeQuestCount++;
        }
        public static void AddQuest(string name, string description = "Выполните квест", string customer = null)
        {
            quests.Add(new Quest(name, description, customer));
            activeQuestCount++;
        }

        private static string GetDefaultName()
        {
            return "Квест " + activeQuestCount.ToString();
        }
        public static void PlayComletedMusic()
        {
            audioSource.Play();
        }
    }
}

