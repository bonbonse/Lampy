using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public Rigidbody2D rb;
        public Vector2 moveDir = Vector2.zero;
        [SerializeField]
        public float speed = 5.0f;
        public bool canBePicked = false;
        public GameObject pickedObj = null;
        public GameObject objInHand = null;

        private Vector2 posRb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
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
        private void OnTriggerStay2D(Collider2D collision)
        {
            canBePicked = true;
            pickedObj = collision.gameObject;
            Debug.Log("Stay " + canBePicked);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            canBePicked = false;
            pickedObj = null;
            Debug.Log("Exit " + canBePicked);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "WorkingPlace")
            {
                // запускаем анимацию работы
                //
            }
        }
    }
}

