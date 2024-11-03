using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed; 
        WaitAndDestroy();
    }
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
