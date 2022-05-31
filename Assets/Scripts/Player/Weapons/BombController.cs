using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
  [Header("Public Attributes")]
  public float timeToLive = 5;
  [Range(0, 5)]
  public float particleSystemDelay = 1f;
  public ParticleSystem smoke;
  [SerializeField] private int damage = 10;

  // Start is called before the first frame update
  void Start()
  {
    Destroy(gameObject, timeToLive);
    Invoke("enableParticleSystem", particleSystemDelay);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    var enemy = collision.collider?.GetComponent<Enemy>();
    enemy?.TakeDamage(damage);
  }

  private void enableParticleSystem()
  {
    AudioManager audioManager = AudioManager.instance;
    audioManager.PlaySound("SmokeBombSFX", false);
    smoke.Play();
  }
}
