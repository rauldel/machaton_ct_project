using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Weapons { Laser, Phaser, SmokeBomb };

public class PlayerWeaponController : MonoBehaviour
{
  [Header("Weapon Dependencies")]
  public PhaserController phaserController;
  public LaserController laserController;
  public BombthrowerController btController;

  [Header("UI Stuff")]
  public Text uiText;

  // Private Attributes
  private Weapons weaponSelected;

  void Awake()
  {
    weaponSelected = Weapons.Phaser;
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
  public void setWeapon(Weapons weapon)
  {
    weaponSelected = weapon;
    this.UpdateWeaponState(weapon);
  }

  public Weapons GetWeaponSelected()
  {
    return weaponSelected;
  }

  public void updateAmmoUI(int uiAmmo)
  {
    switch (weaponSelected)
    {
      case Weapons.Phaser:
        uiText.text = "Phaser - " + uiAmmo;
        break;
      case Weapons.Laser:
        uiText.text = "Laser - " + uiAmmo;
        break;
      case Weapons.SmokeBomb:
        uiText.text = "Smoke Bomb - " + uiAmmo;
        break;
      default:
        break;
    }
  }

  private void UpdateWeaponState(Weapons newWeapon)
  {
    // Desactivate all weapons
    phaserController.gameObject.SetActive(false);
    laserController.gameObject.SetActive(false);
    btController.gameObject.SetActive(false);

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
  }
  #endregion
}
