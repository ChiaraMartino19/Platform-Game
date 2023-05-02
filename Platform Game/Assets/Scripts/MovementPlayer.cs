using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MovementPlayer : MonoBehaviour
{
    float xInicial, yInicial;
    
    public GameObject bulletPrefab;
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private float Horizontal;
    private bool grounded;
    private Animator animator;
    private float lastShoot;
    private int health = 50;
    public Slider barraHealth;
    [SerializeField] ParticleSystem particles;

    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
       rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
            Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);    

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
        }

        else
        {
            grounded = false;
        }
        
        if(Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Space)&& Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }
        barraHealth.value = health;
    }
    private void FixedUpdate()
    {
        rb.velocity =   new Vector2 (Horizontal, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        particles.Play();
    }
    
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;


        GameObject Bullet =  Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<Bullet>().SetDirection(direction);
    }

   public void Hit()
    {
        health = health - 1;
        if (health == 0) 
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Dead");

        }

    }

    public void Reset()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}
