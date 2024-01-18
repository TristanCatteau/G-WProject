using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Sprite : MonoBehaviour
{
    public SpriteRenderer jumpRenderer;
    public Sprite[] jumpArray;
    public SpriteRenderer moveRenderer;
    public Sprite[] moveArray;
    public int currentSprite;
    public int jumpSprite;
    public void ChangeSprite()
    {
        moveRenderer.sprite = moveArray[currentSprite];
        currentSprite++;
        if(currentSprite >= moveArray.Length)
        {
            currentSprite = 0;
        }
    }

    public void Flip()
    {
        moveRenderer.flipX = !moveRenderer.flipX;
    }
    public void ChangeSpriteReverse()
    {
        moveRenderer.sprite = moveArray[currentSprite];
        currentSprite--;
        if(currentSprite < 0)
        {
            currentSprite = moveArray.Length - 1;
        }
    }

    public void ChangeSpriteJump()
    {
        jumpRenderer.sprite = jumpArray[jumpSprite];
        jumpSprite++;
        if(jumpSprite >= jumpArray.Length)
        {
            jumpSprite = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        moveRenderer = gameObject.GetComponent<SpriteRenderer>();
        jumpRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
