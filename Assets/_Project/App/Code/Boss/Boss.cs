using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Boss
{
    public class Boss : MonoBehaviour
    {
        public App app;

        public Rigidbody2D rb;
        public Vector2 moveDir = Vector2.zero;
        public float speed = 5.0f;
        public bool isForwardDir;

        // -1 - idle, 0 - up, 1 - down, 2 - side
        public Animator animator;
        public GameObject curPoint;
        public GameObject nextPoint;
        public bool isIdle = false;

        private Vector2 posRb;

        public GameObject bullet;
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
            if (nextPoint == null)
            {
                nextPoint = curPoint.GetComponent<MovePoint>().GetRandomPointGameobject(isForwardDir);
            }
        }

        public void Move()
        {
            Transform target = nextPoint.transform;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            // Проверка достижения цели
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                curPoint = nextPoint;
                nextPoint = curPoint.GetComponent<MovePoint>().GetRandomPointGameobject(isForwardDir);
                if (nextPoint == null)
                {
                    isForwardDir = !isForwardDir;
                    nextPoint = curPoint.GetComponent<MovePoint>().GetRandomPointGameobject(isForwardDir);
                    Shoot();
                }
            }
            //rb.MovePosition(
            //    (new Vector2(nextPoint.transform.position.x, nextPoint.transform.position.y))
            //    * speed
            //    * Time.deltaTime
            //    + posRb
            //    );
        }
        public void Shoot()
        {
            Debug.Log("Shoooot");
            for (int i = 0; i < 10; i++)
            {
                float angle = 36f * i;
                Quaternion rotation = Quaternion.Euler(0, 0, angle);
                Instantiate(bullet, transform.position, rotation);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Point")
            {
                isIdle = true;
            }
        }
    }
}

