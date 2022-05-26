using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
  #region CloudAttributes
  [Header("Cloud Attributes")]
  [Space]
  [SerializeField]
  private List<Sprite> cloudSpriteList;
  private GameObject player;

  [SerializeField]
  private float destroyingDistance = 20f;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {
    SelectRandomCloudSprite();
    InitCloudMovement();
    player = FindObjectOfType<PlayerController>().gameObject;
  }

  // Update is called once per frame
  void Update()
  {
    CheckAndDestroy();
  }
  #endregion

  #region Utils
  private void SelectRandomCloudSprite()
  {
    if (cloudSpriteList.Count > 0)
    {
      int randomIndex = Random.Range(0, cloudSpriteList.Count - 1);
      int randomOrderInLayer = Random.Range(-5, 5);
      SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
      spriteRenderer.sprite = cloudSpriteList[randomIndex];
      spriteRenderer.sortingOrder = randomOrderInLayer;
    }

  }

  private void InitCloudMovement()
  {
    float randomSpeed = Random.Range(-2, -0.25f);
    Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    rigidbody2D.velocity = transform.right * randomSpeed;
  }

  void CheckAndDestroy()
  {
    float distance = Mathf.Abs(Vector2.Distance(player.transform.position, transform.position));

    if (distance >= destroyingDistance && transform.position.x < player.transform.position.x)
    {
      ParallaxBackground parallaxBackground = FindObjectOfType<ParallaxBackground>();
      parallaxBackground.DecreaseCloudsSpawned();
      Destroy(gameObject);
    }
    else if (GameSceneController.GameIsOver == true)
    {
      Destroy(gameObject);
    }
  }
  #endregion
}
