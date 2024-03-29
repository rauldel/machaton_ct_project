﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
  #region Attributes
  [Header("Basic Attributes")]
  public Transform firePoint;
  public int damage = 5;
  public int ammo = 50;
  public int Ammo
  {
    get
    {
      return ammo;
    }
    set
    {
      ammo = value;
      playerWeaponController.updateAmmoUI(value,Weapons.Laser);
    }
  }
  public LayerMask canHit;

  [Header("Laser dependencies")]
  [SerializeField] private SaveGameController saveGameController;
  [SerializeField] private PlayerWeaponController playerWeaponController;
  public LineRenderer lineRenderer;
  public GameObject impactEffect;
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
        StartCoroutine(ShootLaser());
      }
    }
  }
  #endregion

  #region LaserMethods
  private void SetAmmoFromSaveGameController()
  {
    SaveData data = SaveGameController.GetSavedData();
    Ammo = data.laserAmmo.GetQuantity();
  }

  IEnumerator ShootLaser()
  {
    AudioManager audioManager = AudioManager.instance;
    if (ammo > 0)
    {
      Debug.Log("Laser World Position -> " + firePoint.position);
      RaycastHit2D hitInfo;
      RaycastHit2D hitInfoObstacle = Physics2D.Raycast(firePoint.position, firePoint.right, 1000, LayerMask.GetMask("Obstacle"));
      RaycastHit2D hitInfoCoin = Physics2D.Raycast(firePoint.position, firePoint.right, 1000, LayerMask.GetMask("Coin"));
      RaycastHit2D hitInfoEnemy = Physics2D.Raycast(firePoint.position, firePoint.right, 1000, LayerMask.GetMask("Enemy"));

      List<RaycastHit2D> listRaycasts = new List<RaycastHit2D>() { hitInfoObstacle, hitInfoCoin, hitInfoEnemy };

      hitInfo = getShortestDistance(listRaycasts);

      if (hitInfo)
      {
        Debug.Log("Laser hit " + hitInfo.transform.name);
        hitInfo.transform.GetComponent<Enemy>()?.TakeDamage(damage);
        
        //Instanciar animacion impacto
        Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, hitInfo.point);
      }
      else
      {
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
      }

      lineRenderer.gameObject.SetActive(true);
      lineRenderer.enabled = true;

      yield return new WaitForSeconds(0.05f);

      lineRenderer.enabled = false;
      lineRenderer.gameObject.SetActive(false);
      Ammo--;
      saveGameController.UpdateAmmo(Ammo);
      audioManager.PlaySound("LaserSFX", false);
    }
    else
    {
      audioManager.PlaySound("EmptyWeaponSFX", false);
    }
  }

  private RaycastHit2D getShortestDistance(List<RaycastHit2D> listRaycasts)
  {
    int lowestIndex = 0;

    for (int i = 0; i < listRaycasts.Count; i++) {
      if (listRaycasts[i].distance > 0) {
        lowestIndex = i;
        break;
      }
    }

    for (int i = 0; i < listRaycasts.Count; i++)
    {
      if (listRaycasts[i].distance < listRaycasts[lowestIndex].distance && listRaycasts[i].distance > 0)
      {
        lowestIndex = i;
      }
    }

    return listRaycasts[lowestIndex];
  }
  #endregion
}
