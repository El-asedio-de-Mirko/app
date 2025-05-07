using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float parrySpeedMultiplier = 2f;
    public bool isParrying = false;
    public float parryDuration = 2f;

    public AudioSource footstepAudioSource;
    public AudioClip footstepClip;
    public float footstepInterval = 0.4f; // Tiempo entre pasos

    private Rigidbody2D rb2D;
    private float footstepTimer = 0f;
    public Vector2 moveDirection { get; private set; }
    public Vector2 lastMoveDirection { get; private set; }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lastMoveDirection = Vector2.up;
    }

    void Update()
    {
        InputManager();

        if (Input.GetKeyDown(KeyCode.E))
            StartCoroutine(ActivateParry());

        HandleFootsteps(); // <-- Agregado aquí
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

        bool isMoving = moveDirection.sqrMagnitude > 0.1f;

        if (isMoving)
        {
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.clip = footstepClip;
                footstepAudioSource.loop = true;
                footstepAudioSource.Play();
            }
        }
        else
        {
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop();
            }
        }
    }

    void HandleFootsteps()
    {
        if (moveDirection.sqrMagnitude > 0.1f)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                footstepAudioSource.PlayOneShot(footstepClip);
                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f;
        }
    }

    IEnumerator ActivateParry()
    {
        isParrying = true;
        yield return new WaitForSeconds(parryDuration);
        isParrying = false;
    }
}

