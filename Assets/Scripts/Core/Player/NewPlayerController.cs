using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 moveInput = Vector2.zero;
    Rigidbody2D rb;

    public AudioClip eggSound;
    public AudioClip turkeySound;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Turkey"))
        {
            audioSource.clip = turkeySound;
            audioSource.Play();
        }
        else if(collision.CompareTag("Egg"))
        {
            audioSource.clip = eggSound;
            audioSource.Play();
        }
    }
}