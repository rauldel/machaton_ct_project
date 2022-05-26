using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
  #region ParallaxAttributes
  [Header("Parallax Attributes")]
  [Space]
  [SerializeField]
  private GameObject backgroundSky;

  [SerializeField]
  private GameObject cloudPrefab;

  [SerializeField]
  private GameObject mountainsPrefab;

  private GameObject mountainsInstance;

  private int cloudsSpawned;
  private int maxCloudsInScreen = 30;

  private Transform cameraTransform;
  private Vector3 lastCameraPosition;
  private float cloudSpawnDelay = 1f;
  private float timeSinceLastCloudSpawned;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {
    cameraTransform = Camera.main.transform;
    lastCameraPosition = cameraTransform.position;
    cloudsSpawned = 0;
    timeSinceLastCloudSpawned = 0f;
    mountainsInstance = Instantiate(mountainsPrefab, new Vector3(8.087f, -1.129f, 0f), Quaternion.identity);
  }

  void Update()
  {
    timeSinceLastCloudSpawned += Time.deltaTime;

    if (timeSinceLastCloudSpawned >= cloudSpawnDelay)
    {
      SpawnCloud();
      timeSinceLastCloudSpawned = 0f;
      cloudsSpawned++;
    }
  }

  void LateUpdate()
  {
    Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
    backgroundSky.transform.position += deltaMovement;
    lastCameraPosition = cameraTransform.position;
  }
  #endregion

  #region Utils
  private void SpawnCloud()
  {
    if (cloudsSpawned < maxCloudsInScreen)
    {
      Vector3 topRightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
      Vector3 bottomRightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0));
      float randomYPos = Random.Range(bottomRightBorder.y, topRightBorder.y);
      Vector3 cloudPosition = new Vector3(bottomRightBorder.x + 2, randomYPos, 0f);

      Instantiate(cloudPrefab, cloudPosition, Quaternion.identity);
    }
  }

  public void DecreaseCloudsSpawned()
  {
    cloudsSpawned--;
  }

  public void OnGameOver()
  {
    Destroy(mountainsInstance);
  }
  public void OnRestartGame()
  {
    mountainsInstance = Instantiate(mountainsPrefab, new Vector3(8.087f, -1.129f, 0f), Quaternion.identity);
  }
  #endregion
}
