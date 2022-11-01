using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 moveInput = Vector2.zero;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed; 
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}