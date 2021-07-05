using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public InventoryObject inventory;
    public InventoryObject preparation;
    public static PlayerMovement Instance { get; private set; }

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

    private void Awake()
    {
        Instance = this;

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

        if (Input.GetKeyDown(KeyCode.C))
        {
            inventory.Save();
            preparation.Save();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inventory.Load();
            preparation.Save();
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<groundItem>();
        if (item)
        {
            Item _item = new Item(item.itemOnGround);
            if (inventory.AddItem(_item, 1))
            {
                Destroy(collision.gameObject);
            }
        }
    }
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            inventory.AddItem(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.AddItem(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.AddItem(2, 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventory.AddItem(3, 1);
        }
    }
#endif
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        preparation.Container.Clear();
    }
}
