using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float parrySpeedMultiplier = 2f;
    public bool isParrying = false;
    public float parryDuration = 2f;

    private Rigidbody2D rb2D;
    public Vector2 moveDirection { get; private set; }
    public Vector2 lastMoveDirection { get; private set; }  // ← nueva

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lastMoveDirection = Vector2.up; // dirección por defecto
    }

    void Update()
    {
        InputManager();
        
        if (Input.GetKeyDown(KeyCode.E))
            StartCoroutine(ActivateParry());
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManager() 
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        if (moveDirection.sqrMagnitude > 0.01f)
            lastMoveDirection = moveDirection;
    }

    void Move() 
    {
        float currentSpeed = isParrying ? moveSpeed * parrySpeedMultiplier : moveSpeed;
        rb2D.velocity = moveDirection * currentSpeed;
    }

    IEnumerator ActivateParry()
    {
        isParrying = true;
        yield return new WaitForSeconds(parryDuration);
        isParrying = false;
    }
}

