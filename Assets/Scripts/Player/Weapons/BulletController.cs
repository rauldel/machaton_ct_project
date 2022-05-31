using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 2;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0f;
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 12 es el layer de la cámara
        if (collision.transform.gameObject.layer == 12)
        {
            return;
        }

        AudioManager audioManager = AudioManager.instance;
        PlayerController player = collision.transform.GetComponent<PlayerController>();
        Enemy enemy = collision.transform.GetComponent<Enemy>();
        
        if (player != null)
        {
            // Ignore collisions with self player
            return;
        }

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            audioManager.PlaySound("HitEffectSFX", false);
            Instantiate(impactEffect, collision.transform.position, Quaternion.identity);
        }
        else
        {
            audioManager.PlaySound("HitEffectSFX", false);
            Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}