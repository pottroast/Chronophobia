using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float aggroRange;
    Rigidbody2D rb;
    Vector2 movement;

    public LevelReload levelReload;

    public float moveSpeed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 distance = player.position - transform.position;
        //Debug.Log(distance);
        distance.Normalize();
        movement = distance;
    }
    //This code is very rough and doesnt have patrolling and looks weird in game but it will do for now
    void FixedUpdate()
    {
        //Aggro range
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < aggroRange)
        {
            MoveEnemy(movement);
        }
    }

    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           levelReload.ReloadLevel();
        }
    }
}
