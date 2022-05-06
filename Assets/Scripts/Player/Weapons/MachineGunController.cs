using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MachineGunController : MonoBehaviour
{
  #region Attributes
  [Header("Basic Attributes")]
  public Transform firePoint;
  public int damage = 20;
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
    }
  }

  [Header("Machine Gun dependencies")]
  public GameObject bulletPrefab;

  [System.Serializable]
  public class IntEvent : UnityEvent<int> { }

  [Header("Laser Events")]
  [Space]
  public IntEvent OnShootEvent;
  #endregion

  #region UnityMethods
  // Awake is called when the script instance is being loaded
  void Awake()
  {
    Debug.Log("AWAKE MGC " + ammo);
    if (OnShootEvent == null)
      OnShootEvent = new IntEvent();
  }

  void OnEnable()
  {
    OnShootEvent.Invoke(ammo);
  }

  // Update is called once per frame
  void Update()
  {
    if (!GameSceneController.GameIsPaused)
    {
      if (Input.GetButtonDown("Fire1"))
      {
        ShootBullet();
      }
    }
  }
  #endregion

  #region MachineGunMethods
  void ShootBullet()
  {
    if (ammo > 0)
    {
      Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      ammo--;
      OnShootEvent.Invoke(ammo);
    }
    else
    {
      // should play some empty ammo sound
    }
  }
  #endregion
}
