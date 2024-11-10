using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Interaction
{
    private SpriteRenderer spriteRenderer;
    private int curSpriteNum = 0;
    public List<Sprite> sprites = new List<Sprite>();
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void Interact()
    {
        NextSprite();
    }

    public void NextSprite()
    {
        curSpriteNum++;
        if (curSpriteNum >= sprites.Count)
        {
            curSpriteNum = 0;
        }
        // поменяли спрайт
        spriteRenderer.sprite = sprites[curSpriteNum];
    }
}
