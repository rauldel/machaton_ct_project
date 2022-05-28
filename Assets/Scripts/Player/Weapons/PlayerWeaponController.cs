using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Weapons { None, Laser, Phaser, SmokeBomb };

public class PlayerWeaponController : MonoBehaviour
{
  [Header("Weapon Dependencies")]
  public PhaserController phaserController;
  public LaserController laserController;
  public BombthrowerController btController;

  [Header("UI Stuff")]
  [SerializeField] private GameUIController gameUIController;

  // Private Attributes
  private Weapons weaponSelected;

  void Awake()
  {
    InitialiseWeaponSelected();
    gameUIController.UpdateWeaponsUI(weaponSelected);
    this.setWeapon(weaponSelected);
  }

  void Update()
  {
    if (!GameSceneController.GameIsPaused && !GameSceneController.GameIsOver && !GameSceneController.StoreIsOpen)
    {
      if (Input.GetButtonDown("Weapon 1"))
      {
        this.setWeapon(Weapons.Phaser);
      }
      else if (Input.GetButtonDown("Weapon 2"))
      {
        this.setWeapon(Weapons.Laser);
      }
      else if (Input.GetButtonDown("Weapon 3"))
      {
        this.setWeapon(Weapons.SmokeBomb);
      }
    }
  }

  #region WeaponControllerMethods
  private void InitialiseWeaponSelected()
  {
    SaveData saveData = SaveGameController.GetSavedData();

    if (saveData.hasPhaser)
    {
      weaponSelected = Weapons.Phaser;
    }
    else if (saveData.hasLaser)
    {
      weaponSelected = Weapons.Laser;
    }
    else if (saveData.hasBombthrower)
    {
      weaponSelected = Weapons.SmokeBomb;
    }
    else
    {
      weaponSelected = Weapons.None;
    }
  }
  public void setWeapon(Weapons weapon)
  {
    SaveData saveData = SaveGameController.GetSavedData();
    bool conditionOne = saveData.hasPhaser && weapon == Weapons.Phaser;
    bool conditionTwo = saveData.hasLaser && weapon == Weapons.Laser;
    bool conditionThree = saveData.hasBombthrower && weapon == Weapons.SmokeBomb;

    if (conditionOne || conditionTwo || conditionThree || weapon == Weapons.None)
    {
      weaponSelected = weapon;
      this.UpdateWeaponState(weapon);
    }
  }

  public Weapons GetWeaponSelected()
  {
    return weaponSelected;
  }

  public void updateAmmoUI(int uiAmmo, Weapons weapon)
  {
    if (weaponSelected == weapon)
    {
      gameUIController.SetAmmoText(uiAmmo);
    }
  }

  public void DeactivateAllWeapons()
  {
    phaserController.gameObject.SetActive(false);
    laserController.gameObject.SetActive(false);
    btController.gameObject.SetActive(false);
  }

  private void UpdateWeaponState(Weapons newWeapon)
  {
    DeactivateAllWeapons();

    // Activate weapon we're told to
    switch (newWeapon)
    {
      case Weapons.Phaser:
        phaserController.gameObject.SetActive(true);
        break;
      case Weapons.Laser:
        laserController.gameObject.SetActive(true);
        break;
      case Weapons.SmokeBomb:
        btController.gameObject.SetActive(true);
        break;
      default:
        break;
    }
    gameUIController.UpdateWeaponsUI(newWeapon);
  }

  public void UpdateAllWeaponsAmmo()
  {
    SaveData saveData = SaveGameController.GetSavedData();

    phaserController.Ammo = saveData.phaserAmmo.quantity;
    laserController.Ammo = saveData.laserAmmo.quantity;
    btController.Ammo = saveData.smokeBombAmmo.quantity;
  }
  #endregion
}
