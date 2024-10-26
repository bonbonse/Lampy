using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveDir = Vector2.zero;
    [SerializeField]
    float speed = 5.0f;
    bool canBePicked = false;
    GameObject pickedObj = null;
    GameObject objInHand = null;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            // TODO: тернарный оператор
            if (objInHand != null)
            {
                Drop();
            }
            else
            {
                Take();
            }
        }
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
    void Take()
    {
        if (canBePicked)
        {
            objInHand = pickedObj;
            objInHand.GetComponent<Rigidbody2D>().isKinematic = true;
            objInHand.transform.SetParent(rb.transform);
        }
    }
    void Drop()
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
}
