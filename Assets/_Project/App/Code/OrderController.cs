using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    SpriteRenderer spriteRendererPlayer;
    private void Start()
    {
        spriteRendererPlayer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null) {
            if (collision.tag != "Grid")
            {
                SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
                if (spriteRenderer == null) { return; }
                if (spriteRenderer.sortingOrder == spriteRenderer.sortingOrder)
                {
                    if (transform.position.y > collision.transform.position.y)
                        collision.GetComponent<SpriteRenderer>().sortingLayerName = "3";
                    else
                        collision.GetComponent<SpriteRenderer>().sortingLayerName = "1";
                    Debug.Log(collision.GetComponent<SpriteRenderer>().sortingLayerName + collision.name);
                }
            }
        }
    }
}
