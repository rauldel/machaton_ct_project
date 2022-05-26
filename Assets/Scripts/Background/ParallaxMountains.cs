using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMountains : MonoBehaviour
{
  #region MountainsAttributes
  [Header("Mountains Attributes")]
  [Space]
  [SerializeField]
  private List<GameObject> mountainList;

  [SerializeField]
  private Vector2 parallaxEffectMultiplier = new Vector2(0.1f, 0.75f);

  [SerializeField]
  private float maxThresholdMovingMountain = 15f;

  private PlayerController playerController;
  private Transform cameraTransform;
  private Vector3 lastCameraPosition;
  private Transform lastMountainEndPositionTransform;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {
    playerController = FindObjectOfType<PlayerController>();
    cameraTransform = Camera.main.transform;
    lastCameraPosition = cameraTransform.position;
    GetLastMountainTransform();
  }

  // Update is called once per frame
  void Update()
  {
    foreach (GameObject mountain in mountainList)
    {
      if (CheckIfMountainIsBehind(mountain) == true)
      {
        MoveMountainToTheEnd(mountain);
      }
    }
  }

  // LateUpdate is called after all Update have finished
  void LateUpdate()
  {
    Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
    deltaMovement *= parallaxEffectMultiplier;
    foreach (GameObject mountain in mountainList)
    {
      mountain.transform.position = new Vector3(mountain.transform.position.x + deltaMovement.x, mountain.transform.position.y + deltaMovement.y, 0);
    }
    lastCameraPosition = cameraTransform.position;
  }
  #endregion

  #region Utils
  private void GetLastMountainTransform()
  {
    int index = 0;
    for (int i = 0; i < mountainList.Count; i++)
    {
      if (mountainList[i].transform.position.x > mountainList[index].transform.position.x)
      {
        index = i;
      }
    }
    lastMountainEndPositionTransform = mountainList[index].transform.GetChild(0);
  }

  private bool CheckIfMountainIsBehind(GameObject mountain)
  {
    Vector3 mountainEndPosition = mountain.transform.GetChild(0).transform.position;
    float playerDistance = Mathf.Abs(Vector2.Distance(playerController.transform.position, mountainEndPosition));

    if (mountainEndPosition.x < playerController.transform.position.x && playerDistance > maxThresholdMovingMountain)
    {
      return true;
    }
    return false;
  }

  private void MoveMountainToTheEnd(GameObject mountain)
  {
    Vector3 mountainPosition = mountain.transform.position;
    mountainPosition.x = lastMountainEndPositionTransform.position.x;
    mountain.transform.position = mountainPosition;

    GetLastMountainTransform();
  }

  #endregion
}
