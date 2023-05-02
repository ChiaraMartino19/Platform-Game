using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.velocity = direction * speed;
    }

    public void SetDirection(Vector2 Direction)
    {
        direction = Direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        MovementPlayer player = collision.GetComponent<MovementPlayer>();
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (player != null)
        {
            player.Hit();
        }

        if (enemy != null)
        {
            enemy.Hit();
        }
        DestroyBullet();
    }
   
}
