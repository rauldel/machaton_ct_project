using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaserController : MonoBehaviour
{
  #region Attributes
  [Header("Basic Attributes")]
  public Transform firePoint;
  public int damage = 20;
  public int ammo;
  public int Ammo
  {
    get
    {
      return ammo;
    }
    set
    {
      ammo = value;
      playerWeaponController.updateAmmoUI(value, Weapons.Phaser);
    }
  }

  [Header("Phaser dependencies")]
  [SerializeField] private SaveGameController saveGameController;
  [SerializeField] private PlayerWeaponController playerWeaponController;
  public GameObject bulletPrefab;
  #endregion

  #region UnityMethods
  // Awake is called when the script instance is being loaded
  void Awake()
  {
    SetAmmoFromSaveGameController();
  }

  void OnEnable()
  {
    SetAmmoFromSaveGameController();
  }

  // Update is called once per frame
  void Update()
  {
    if (!GameSceneController.GameIsPaused && !GameSceneController.GameIsOver && !GameSceneController.StoreIsOpen)
    {
      if (Input.GetButtonDown("Fire1"))
      {
        ShootBullet();
      }
    }
  }
  #endregion

  #region PhaserMethods
  private void SetAmmoFromSaveGameController()
  {
    SaveData data = SaveGameController.GetSavedData();
    Ammo = data.phaserAmmo.GetQuantity();
  }

  void ShootBullet()
  {
    AudioManager audioManager = AudioManager.instance;
    if (ammo > 0)
    {
      Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      Ammo--;
      saveGameController.UpdateAmmo(Ammo);
      audioManager.PlaySound("PhaserSFX", false);
    }
    else
    {
      audioManager.PlaySound("EmptyWeaponSFX", false);
    }
  }
  #endregion
}
