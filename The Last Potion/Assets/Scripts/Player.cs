using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float moveSpeed = 2f, sprintSpeed = 5f;
    public LayerMask interactableLayer;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;

    public Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private UI_Inventory brewingInventory;
    [SerializeField] private Cauldron cauldron;
    [SerializeField] private Shelf shelf;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("lastMoveY", -1);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        brewingInventory.SetInventory(inventory);
        cauldron.SetInventory(inventory);
        shelf.SetInventory(inventory);
    }

    public void Clear()
    {
        inventory.ClearInventory();
        uiInventory.SetInventory(inventory);
        brewingInventory.SetInventory(inventory);
        cauldron.SetInventory(inventory);
        shelf.SetInventory(inventory);
    }

    public void HandleUpdate()
    {
        //Movement Axis / squash vertical axis by 2
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Same speed diagonally
        movement.Normalize();

        //Set Animator Parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        //Character idle in direction he is facing
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == -1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1)
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
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + movement * sprintSpeed * Time.fixedDeltaTime);

        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();

        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroyItself();
            
        }
    }
}
