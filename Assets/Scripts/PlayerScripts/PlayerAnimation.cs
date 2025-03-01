using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;

    public Sprite normalSprite;
    public Sprite parrySprite;

    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (pm.moveDirection.x != 0 || pm.moveDirection.y != 0)
        {
            am.SetBool("Move", true);
        }
        else
        {
            am.SetBool("Move", false);
        }

        SpriteDirectionChecker();
        CheckParryState();
    }

    void SpriteDirectionChecker()
    {
        if (pm.moveDirection.x > 0)
        {
            sr.flipX = true; 
        }
        else if (pm.moveDirection.x < 0)
        {
            sr.flipX = false;
        }
    }

    void CheckParryState()
    {
        if (pm.isParrying)
        {
            sr.sprite = parrySprite;
        }
        else
        {
            sr.sprite = normalSprite;
        }
    }
}
