using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
  #region InventoryAttrbiutes
  [Header("Inventory Attributes")]
  [Space]
  [SerializeField]
  private InventoryListController inventoryListController;

  [SerializeField]
  private PlayerController playerController;

  [SerializeField]
  private Text currentCoinsText;
  [SerializeField]
  private Text earnedCoinsText;
  [SerializeField]
  private Text spentCoinsText;

  [SerializeField]
  private GameObject phaserBadge;
  [SerializeField]
  private GameObject laserBadge;
  [SerializeField]
  private GameObject cannonBadge;

  private List<KeyValuePair<string, int>> inventoryList;
  #endregion

  #region UnityMethods
  // Start is called before the first frame update
  void Start()
  {
    initPauseMenu();
  }

  void OnEnable()
  {
    initPauseMenu();
  }

  // Update is called once per frame
  void Update()
  {

  }
  #endregion

  #region Utils
  public void initPauseMenu()
  {
    inventoryList = new List<KeyValuePair<string, int>>();
    SaveData saveData = SaveGameController.GetSavedData();

    // Inventory
    if (saveData.potionsCount > 0)
    {
      KeyValuePair<string, int> pair = new KeyValuePair<string, int>("Potion", saveData.potionsCount);
      inventoryList.Add(pair);
    }
    if (saveData.superPotionsCount > 0)
    {
      KeyValuePair<string, int> pair = new KeyValuePair<string, int>("Superpotion", saveData.superPotionsCount);
      inventoryList.Add(pair);
    }
    if (saveData.hyperPotionsCount > 0)
    {
      KeyValuePair<string, int> pair = new KeyValuePair<string, int>("Hyperpotion", saveData.hyperPotionsCount);
      inventoryList.Add(pair);
    }
    if (saveData.phaserAmmo.GetQuantity() > 0)
    {
      KeyValuePair<string, int> pair = new KeyValuePair<string, int>("Phaser charge", saveData.phaserAmmo.GetQuantity());
      inventoryList.Add(pair);
    }
    if (saveData.laserAmmo.GetQuantity() > 0)
    {
      KeyValuePair<string, int> pair = new KeyValuePair<string, int>("Laser charge", saveData.laserAmmo.GetQuantity());
      inventoryList.Add(pair);
    }
    if (saveData.smokeBombAmmo.GetQuantity() > 0)
    {
      KeyValuePair<string, int> pair = new KeyValuePair<string, int>("Cannon charge", saveData.smokeBombAmmo.GetQuantity());
      inventoryList.Add(pair);
    }

    inventoryListController.PopulateList(inventoryList);

    // Stats
    if (saveData.hasPhaser)
    {
      phaserBadge.SetActive(true);
    }
    if (saveData.hasLaser)
    {
      laserBadge.SetActive(true);
    }
    if (saveData.hasBombthrower)
    {
      cannonBadge.SetActive(true);
    }

    currentCoinsText.text = "" + saveData.playerCoins;
    earnedCoinsText.text = "" + saveData.totalMoneyEarned;
    spentCoinsText.text = "" + saveData.totalMoneySpent;
  }

  public void OnConsumeItem(string name)
  {
    SaveData saveData = SaveGameController.GetSavedData();
    AudioManager audioManager = AudioManager.instance;
    audioManager.PlaySound("ConsumeItemSFX", false);
    switch (name)
    {
      case "Potion":

        saveData.potionsCount = saveData.potionsCount - 1;
        SaveGameController.WriteDataToStorage(saveData);

        // We do this, as a semi hardcoded way of increasing life points.
        // In the future, this value will be calculated from CT info.
        Potion p = new Potion();

        playerController.OnIncrementLife(p.GetValue());
        break;
      case "Superpotion":
        saveData.potionsCount = saveData.superPotionsCount - 1;
        SaveGameController.WriteDataToStorage(saveData);

        // We do this, as a semi hardcoded way of increasing life points.
        // In the future, this value will be calculated from CT info.
        SuperPotion sp = new SuperPotion();

        playerController.OnIncrementLife(sp.GetValue());
        break;
      case "Hyperpotion":
        saveData.potionsCount = saveData.hyperPotionsCount - 1;
        SaveGameController.WriteDataToStorage(saveData);

        // We do this, as a semi hardcoded way of increasing life points.
        // In the future, this value will be calculated from CT info.
        HyperPotion hp = new HyperPotion();

        playerController.OnIncrementLife(hp.GetValue());
        break;
      default:
        break;
    }

    initPauseMenu();
  }
  #endregion
}
