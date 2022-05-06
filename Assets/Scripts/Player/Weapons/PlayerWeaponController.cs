using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Weapons { Laser, MachineGun, SmokeBomb };

public class PlayerWeaponController : MonoBehaviour
{
  [Header("Weapon Dependencies")]
  public MachineGunController mgController;
  public LaserController laserController;
  public LanzagranadasController lgController;

  [Header("UI Stuff")]
  public Text uiText;

  // Private Attributes
  private Weapons weaponSelected;


  // Start is called before the first frame update
  void Awake()
  {
    weaponSelected = Weapons.MachineGun;
    Debug.Log("AWAKE PWC");
    this.setWeapon(weaponSelected);
  }

  // Update is called once per frame
  void Update()
  {
    if (!GameSceneController.GameIsPaused)
    {
      if (Input.GetButtonDown("Weapon 1"))
      {
        this.setWeapon(Weapons.MachineGun);
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

  public void updateOnShootEvent(int uiAmmo)
  {
    Debug.Log("UOSE - " + uiAmmo);
    switch (weaponSelected)
    {
      case Weapons.MachineGun:
        uiText.text = "Machine Gun - " + uiAmmo;
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
    // Desactivamos todas las armas
    mgController.gameObject.SetActive(false);
    laserController.gameObject.SetActive(false);
    lgController.gameObject.SetActive(false);

    // Activamos la que se nos ordena
    switch (newWeapon)
    {
      case Weapons.MachineGun:
        mgController.gameObject.SetActive(true);
        break;
      case Weapons.Laser:
        laserController.gameObject.SetActive(true);
        break;
      case Weapons.SmokeBomb:
        lgController.gameObject.SetActive(true);
        break;
      default:
        break;
    }
  }
  #endregion
}
