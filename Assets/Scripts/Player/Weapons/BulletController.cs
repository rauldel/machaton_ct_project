using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

  public float speed = 20f;
  public int damage = 10;
  public Rigidbody2D rb;
  public GameObject impactEffect;

  // Start is called before the first frame update
  void Start()
  {
    rb.gravityScale = 0f;
    rb.velocity = transform.right * speed;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    // 12 es el layer de la cámara
    if (collision.transform.gameObject.layer == 12)
    {
      return;
    }

    Debug.Log(collision.name);
    AudioManager audioManager = AudioManager.instance;
    PlayerController player = collision.transform.GetComponent<PlayerController>();
    BeeController bee = collision.transform.GetComponent<BeeController>();
    // HeadlessController headless = collision.transform.GetComponent<HeadlessController>();

    if (player != null)
    {
      // Ignore collisions with self player
      return;
    }

    if (bee != null)
    {
      audioManager.PlaySound("HitEffectSFX", false);
      bee.TakeDamage(damage);
      Instantiate(impactEffect, collision.transform.position, Quaternion.identity);
    }
    /* else if (headless != null)
    {
      headless.TakeDamage(damage);
      Instantiate(impactEffect, collision.transform.position, Quaternion.identity);
    } */
    else
    {
      audioManager.PlaySound("HitEffectSFX", false);
      Instantiate(impactEffect, gameObject.transform.position, Quaternion.identity);
    }

    Destroy(gameObject);
  }
}
