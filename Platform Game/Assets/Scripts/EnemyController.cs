using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    private float lastShoot;
    private int health = 5;
    public Slider healthBarra;
   
    
    void Update()
    {
        if(player == null) return;
        Vector3 direction = player.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time> lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }

        
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;


        GameObject Bullet = Instantiate(bulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<Bullet>().SetDirection(direction);
    }
    public void Hit()
    {
        health = health - 1;
        healthBarra.value = health;
        if (health == 0) Destroy(gameObject);
    }
}
