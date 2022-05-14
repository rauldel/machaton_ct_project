using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
  #region LevelGeneratorAttributes
  [Header("Level Generator Attributes")]
  [Space]
  [SerializeField]
  private Transform initialPlatform;
  
  [SerializeField]
  private List<Transform> levelPartList;

  [SerializeField]
  private PlayerController player;

  [SerializeField]
  [Range(1, 500)]
  private float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50;

  [SerializeField]
  [Range(1, 500)]
  private float PLAYER_DISTANCE_DESTROY_LEVEL_PART = 5;

  [SerializeField]
  [Range(1, 20)]
  private int STARTING_SPAWN_LEVEL_PARTS = 5;

  private Vector3 lastEndPosition;
  private List<Transform> spawnedPlatformList;
  #endregion

  void Awake()
  {
    spawnedPlatformList = new List<Transform>();
    spawnedPlatformList.Add(GameObject.Find("InitialPlatforms").transform);
    lastEndPosition = initialPlatform.Find("EndPosition").position;
    for (int i = 0; i < STARTING_SPAWN_LEVEL_PARTS; i++)
    {
      SpawnLevelPart();
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (Vector3.Distance(player.gameObject.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
    {
      SpawnLevelPart();
    }

    DestroyPastParts();
  }

  private void SpawnLevelPart()
  {
    Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
    Transform lastPartLevelTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);

    lastEndPosition = lastPartLevelTransform.Find("EndPosition").position;
    spawnedPlatformList.Add(lastPartLevelTransform);
  }

  private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
  {
    Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
    return levelPartTransform;
  }

  private void DestroyPastParts()
  {
    List<Transform> deleteList = new List<Transform>();
    for (int i = 0; i < spawnedPlatformList.Count; i++)
    {
      Vector3 lastPos = spawnedPlatformList[i].Find("EndPosition").position;
      if (lastPos.x < player.gameObject.transform.position.x && Vector2.Distance(player.gameObject.transform.position, lastPos) > PLAYER_DISTANCE_DESTROY_LEVEL_PART)
      {
        deleteList.Add(spawnedPlatformList[i]);
      }
    }
    foreach (Transform platform in deleteList)
    {
      spawnedPlatformList.Remove(platform);
      Destroy(platform.gameObject);
    }
  }

  public void RestartGame() {
    foreach (Transform platform in spawnedPlatformList)
    {
      Destroy(platform.gameObject);
    }
    spawnedPlatformList.RemoveAll(platform => true);

    Transform initialPartReinstanced = Instantiate(initialPlatform, new Vector3(0,0,0), Quaternion.identity);
    lastEndPosition = initialPartReinstanced.Find("EndPosition").position;
    spawnedPlatformList.Add(initialPartReinstanced);
  }
}
