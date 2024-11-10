using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public App app;

        public Rigidbody2D rb;
        public Vector2 moveDir = Vector2.zero;
        [SerializeField]
        public float speed = 5.0f;
        public bool canBePicked = false;
        public GameObject pickedObj = null;
        public GameObject objInHand = null;
        public GameObject chairSelected = null;
        public GameObject coolSelected = null;
        public GameObject humanSelected = null;
        public GameObject chair = null;
        public GameObject interactionSelected = null;
        public static bool canClickE = false;

        public float tiredSpeedInSeconds = 0.5f;
        public float tiredValueProgress = -1f;
        public float workSpeedInSeconds = 2f;
        public float workValueProgress = 1f;

        public Fatique fatique;
        public JobDone jobDone;

        // -1 - idle, 0 - up, 1 - down, 2 - side
        public Animator animator;

        private Vector2 posRb;

        public AudioSource audioSource;
        public AudioClip[] musicClips; // Массив аудиофайлов


        void Awake()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
            }
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
            }
            posRb = new Vector2(transform.position.x, transform.position.y);
        }
        
        public void PlayMusic(int clipIndex)
        {
            if (clipIndex < musicClips.Length)
            {
                audioSource.clip = musicClips[clipIndex];
                audioSource.Play();
            }
        }

        public void Move()
        {
            posRb = transform.position;
            rb.MovePosition(moveDir * speed * Time.deltaTime + posRb);
        }
        public void Take()
        {
            if (canBePicked)
            {
                objInHand = pickedObj;
                objInHand.GetComponent<Rigidbody2D>().isKinematic = true;
                objInHand.transform.SetParent(rb.transform);
            }
        }
        public void Drop()
        {
            objInHand.transform.SetParent(null);
            objInHand.GetComponent<Rigidbody2D>().isKinematic = false;
            objInHand = null;
        }
        public void Sit()
        {
            if (chairSelected != null)
            {
                chair = chairSelected;
                chairSelected.gameObject.SetActive(false);
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Chair":
                    chairSelected = collision.gameObject;
                    App._app.windows.ShowClickE();
                    break;
                case "Cool":
                    coolSelected = collision.gameObject;
                    App._app.windows.ShowClickE();
                    break;
                case "Human":
                    humanSelected = collision.gameObject;
                    App._app.windows.ShowClickE();
                    break;
                case "Interaction":
                    interactionSelected = collision.gameObject;
                    App._app.windows.ShowClickE();
                    break;
                default:
                    return;
            }
            //if (collision.tag != "Grid")
            //{
            //    canBePicked = true;
            //    pickedObj = collision.gameObject;
            //}
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Chair":
                    chairSelected = null;
                    break;
                case "Cool":
                    coolSelected = null;
                    break;
                case "Human":
                    humanSelected = null;
                    break;
                 case "Interaction":
                    interactionSelected = null;
                    break;
                default:
                    break;
            }
            if (
                chairSelected == null 
                && coolSelected == null
                && humanSelected == null
                && interactionSelected == null
                )
            {
                App._app.windows.UnShowClickE();
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Bullet")
            {
                App.GameOver();
                Notification.SendNotification(
                    "Вам неповезло и вы попали под сокращение :(" +
                    "\nОтдохните как следует" +
                    "и снова устройтесь на работу",
                    "Выйти",
                    true
                    );
            }
        }
    }
}

