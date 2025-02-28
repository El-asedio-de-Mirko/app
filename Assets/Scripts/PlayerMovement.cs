using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb2D;
    Vector2 moveDirection;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        InputManager();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManager() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move() {
        rb2D.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
