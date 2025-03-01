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
    public Vector2 moveDirection;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InputManager();
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ActivateParry());
        }
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
        float currentSpeed = isParrying ? moveSpeed * parrySpeedMultiplier : moveSpeed;
        rb2D.velocity = new Vector2(moveDirection.x * currentSpeed, moveDirection.y * currentSpeed);
    }

    IEnumerator ActivateParry()
    {
        isParrying = true;
        yield return new WaitForSeconds(parryDuration);
        isParrying = false;
    }
}
