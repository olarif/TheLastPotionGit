using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float moveSpeed = 2f, sprintSpeed = 5f;

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;

    public Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private Brewing brewInventory;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("lastMoveY", -1);
    }

    private void Awake()
    {
        Instance = this;
        InitInventory();
    }

    public void InitInventory()
    {
        inventory = new Inventory();
        brewInventory.SetInventory(inventory);
        uiInventory.SetInventory(inventory);
    }

    public void Clear()
    {
        inventory.ClearInventory();
        brewInventory.SetInventory(inventory);
        uiInventory.SetInventory(inventory);
    }

    public void HandleUpdate()
    {
        //Movement Axis / squash vertical axis by 2
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical") / 1.75f;

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
    }

    public void StopWalking()
    {
        movement.x = 0;
        movement.y = 0;
        animator.SetFloat("Speed", 0);
        animator.SetFloat("lastMoveY", -1);
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
            if (inventory.itemList.Count < 4)
            {
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroyItself();
            }
        }
    }
}
