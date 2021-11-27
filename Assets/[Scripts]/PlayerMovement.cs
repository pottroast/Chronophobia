using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    public List<string> items;

    public GameObject MemCore;

    void Start()
    {
        items = new List<string>();
    }

    void Update()
    {
        ProcessInputs();
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Player doesnt move faster diagonally
        movement = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    //Memcore Pickup I hope it works
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MemCore"))
        {
            //Knows what type of object is picked up refrencing memcore script
            string itemType = collision.gameObject.GetComponent<MemCore>().itemType;
            MemCore.transform.position = new Vector2(-100, -100);
            print("Collected " + itemType);

            items.Add(itemType);
            //Prints to console how many memcores player has picked up
            print("Number of MemCores " + items.Count);
        }
    }
}
