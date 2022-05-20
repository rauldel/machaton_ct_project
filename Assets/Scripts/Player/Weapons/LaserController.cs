using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserController : MonoBehaviour
{
    [SerializeField] private SaveGameController saveGameController;
    [SerializeField] private PlayerWeaponController playerWeaponController;
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
            playerWeaponController.updateAmmoUI(value);
        }
    }
    public LayerMask canHit;

    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }

    [Header("Laser dependencies")]
    public LineRenderer lineRenderer;
    public GameObject impactEffect;

    [Header("Laser Events")]
    [Space]
    public IntEvent OnShootEvent;
    #endregion

    #region UnityMethods
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (OnShootEvent == null)
        {
            OnShootEvent = new IntEvent();
        }
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
                StartCoroutine(ShootLaser());
            }
        }
    }
    #endregion

    private void SetAmmoFromSaveGameController()
    {
        SaveData data = saveGameController.GetSavedData();
        Ammo = data.laserAmmo;
    }

    #region LaserMethods
    IEnumerator ShootLaser()
    {
        if (ammo > 0)
        {
            Debug.Log("Laser Local Position -> " + firePoint.localPosition);
            Debug.Log("Laser World Position -> " + firePoint.position);
            RaycastHit2D hitInfo;
            RaycastHit2D hitInfoObstacle = Physics2D.Raycast(firePoint.position, firePoint.right, 10000, LayerMask.GetMask("Obstacle"));
            RaycastHit2D hitInfoCoin = Physics2D.Raycast(firePoint.position, firePoint.right, 10000, LayerMask.GetMask("Coin"));
            RaycastHit2D hitInfoEnemy = Physics2D.Raycast(firePoint.position, firePoint.right, 10000, LayerMask.GetMask("Enemy"));

            switch (getBiggestValue(hitInfoObstacle.distance, hitInfoCoin.distance, hitInfoEnemy.distance))
            {
                case 0:
                    hitInfo = hitInfoObstacle;
                    break;
                case 1:
                    hitInfo = hitInfoCoin;
                    break;
                default:
                case 2:
                    hitInfo = hitInfoEnemy;
                    break;
            }



            if (hitInfo)
            {
                Debug.Log("Laser hit " + hitInfo.transform.name);

                BeeController bee = hitInfo.transform.GetComponent<BeeController>();
                HeadlessController headless = hitInfo.transform.GetComponent<HeadlessController>();

                if (bee != null)
                {
                    bee.TakeDamage(damage);
                }
                else if (headless != null)
                {
                    headless.TakeDamage(damage);
                }

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
            OnShootEvent.Invoke(Ammo);
        }
        else
        {
            // should play some empty ammo sound
        }
    }


    private int getBiggestValue(float valueA, float valueB, float valueC)
    {
        if (valueA > valueB && valueA > valueC)
        {
            return 0;
        }
        else if (valueB > valueA && valueB > valueC)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
    #endregion
}
