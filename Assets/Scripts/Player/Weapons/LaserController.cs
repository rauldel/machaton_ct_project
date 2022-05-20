using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserController : MonoBehaviour
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
    OnShootEvent.Invoke(ammo);
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

      List<RaycastHit2D> listRaycasts = new List<RaycastHit2D>() { hitInfoObstacle, hitInfoCoin, hitInfoEnemy };

      hitInfo = getShortestDistance(listRaycasts);

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
      ammo--;
      OnShootEvent.Invoke(ammo);
    }
    else
    {
      // should play some empty ammo sound
    }
  }

  private RaycastHit2D getShortestDistance(List<RaycastHit2D> listRaycasts)
  {
    int lowestIndex = 0;

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
