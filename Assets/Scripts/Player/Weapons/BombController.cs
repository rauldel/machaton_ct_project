using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
  //Public Attributes
  public float timeToLive = 5;
  public float launchForce = 4;

  // Start is called before the first frame update
  void Start()
  {
    GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    Destroy(gameObject, timeToLive);
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnCollisionEnter2D(Collision2D collision)
  {

  }
}
