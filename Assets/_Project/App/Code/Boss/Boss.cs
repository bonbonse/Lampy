using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class Boss : MonoBehaviour
    {
        public App app;

        public Rigidbody2D rb;
        public Vector2 moveDir = Vector2.zero;
        public float speed = 5.0f;

        // -1 - idle, 0 - up, 1 - down, 2 - side
        public Animator animator;

        private Vector2 posRb;
        void Start()
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
    }
}

