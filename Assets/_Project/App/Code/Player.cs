using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveDir = Vector2.zero;
    [SerializeField]
    float speed = 5.0f;


    private Vector2 posRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posRb = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        HandleUpdate();
        LogicUpdate();
    }
    void FixedUpdate()
    {
        Move();
    }
    void HandleUpdate()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Vertical");
    }
    void LogicUpdate()
    {
        posRb.x = transform.position.x;
        posRb.y = transform.position.y;
    }
    void Move()
    {
        rb.MovePosition(moveDir * speed * Time.deltaTime + posRb);
    }
}
