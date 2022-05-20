using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MachineGunController : MonoBehaviour
{
    [SerializeField] private SaveGameController saveGameController;
    [SerializeField] private PlayerWeaponController playerWeaponController;
    #region Attributes
    [Header("Basic Attributes")]
    public Transform firePoint;
    public int damage = 20;
    private int ammo;

    public int Ammo
    {
        get
        {
            return ammo;
        }
        set
        {
            ammo = value;
            playerWeaponController.updateAmmoUI(value);
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
        Debug.Log("AWAKE MGC " + Ammo);
        if (OnShootEvent == null)
            OnShootEvent = new IntEvent();
    }

    private void SetAmmoFromSaveGameController()
    {
        SaveData data = saveGameController.GetSavedData();
        Ammo = data.machineGunAmmo;

    }

    void OnEnable()
    {
        SetAmmoFromSaveGameController();
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
        if (Ammo > 0)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Ammo--;
            OnShootEvent.Invoke(Ammo);
        }
        else
        {
            // should play some empty ammo sound
        }
    }
    #endregion
}
