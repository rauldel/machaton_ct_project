using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
  [Header("Public Attributes")]
  public float timeToLive = 5;
  [Range(0,5)]
  public float particleSystemDelay = 1f;
  public GameObject smoke;

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

  }

  private void enableParticleSystem() {
    if (smoke.gameObject.activeSelf == false) {
      smoke.SetActive(true);
    }
  }
}
