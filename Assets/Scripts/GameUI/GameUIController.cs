using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
  [Header("Player UI Attributes")]
  [Space]
  [SerializeField]
  private Text uiAmmoText;
  [SerializeField]
  private Text uiLifeText;
  [SerializeField]
  private Text uiCoinText;
  [SerializeField]
  private GameObject phaserSquare;
  [SerializeField]
  private GameObject laserSquare;
  [SerializeField]
  private GameObject cannonSquare;

  public void SetLifeText(int lifes)
  {
    uiLifeText.text = "" + lifes;
  }

  public void SetAmmoText(int ammo)
  {
    uiAmmoText.text = "" + ammo;
  }

  public void SetCoinText(int coins)
  {
    uiCoinText.text = "" + coins;
  }

  public void UpdateWeaponsUI(Weapons selectedWeapon)
  {
    SaveData saveData = SaveGameController.GetSavedData();
    if (saveData.hasPhaser)
    {
      phaserSquare.gameObject.SetActive(true);
    }
    if (saveData.hasLaser)
    {
      laserSquare.gameObject.SetActive(true);
    }
    if (saveData.hasBombthrower)
    {
      cannonSquare.gameObject.SetActive(true);
    }

    if (selectedWeapon == Weapons.Phaser)
    {
      phaserSquare.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 0.25f);
      laserSquare.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
      cannonSquare.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
    }
    else if (selectedWeapon == Weapons.Laser)
    {
      phaserSquare.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
      laserSquare.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 0.25f);
      cannonSquare.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
    }
    else if (selectedWeapon == Weapons.SmokeBomb)
    {
      phaserSquare.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
      laserSquare.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
      cannonSquare.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 0.25f);
    }


  }
}
