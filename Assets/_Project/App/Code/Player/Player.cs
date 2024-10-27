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
        public GameObject chair = null;

        public float tiredSpeedInSeconds = 0.5f;
        public float tiredValueProgress = -1f;
        public float workSpeedInSeconds = 2f;
        public float workValueProgress = 1f;

        public Fatique fatique;
        public JobDone jobDone;

        // -1 - idle, 0 - up, 1 - down, 2 - side
        public Animator animator;

        private Vector2 posRb;

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
            posRb = new Vector2(transform.position.x, transform.position.y);
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
                Debug.Log("Sit " + chair);
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag != "Grid")
            {
                canBePicked = true;
                pickedObj = collision.gameObject;
            }
            if (collision.tag == "Chair")
            {
                chairSelected = collision.gameObject;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            canBePicked = false;
            pickedObj = null;
            chairSelected = null;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Bullet")
            {
                app.notification.SendNotification("Вам неповезло и вы попали под сокращение:(");
                StartCoroutine(ReadAndEnd());
            }
        }
        IEnumerator ReadAndEnd()
        {
            yield return new WaitForSeconds(7);
            SceneManager.LoadScene("Menu");
        }
    }
}

