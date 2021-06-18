using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f, sprintSpeed = 5f;
    public LayerMask interactableLayer;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    public void HandleUpdate()
    {
        //Movement Axis / squash vertical axis by 2
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical") / 2;

        //Same speed diagonally
        movement.Normalize();

        //Set Animator Parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetFloat("lastMoveY", -1);

        //Character idle in direction he is facing
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        var collider = Physics2D.OverlapCircle(transform.position, 0.01f, interactableLayer);
        if(collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + movement * sprintSpeed * Time.fixedDeltaTime);

        } else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
