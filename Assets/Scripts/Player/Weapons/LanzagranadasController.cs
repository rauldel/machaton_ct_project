using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LanzagranadasController : MonoBehaviour
{

  #region Attributes
  [Header("Basic Attributes")]
  public Transform firePoint;
  [SerializeField]
  private int damage = 20;
  [SerializeField]
  private int ammo = 50;
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

  [SerializeField]
  private int launchForce = 1;

  [Header("Weapon dependencies")]
  public GameObject smokeBombPrefab;

  [Header("Curve Trajectory Renderer")]
  public LineRenderer trajectoryRenderer;
  [Range(2, 30)]
  public int resolution;
  private Vector2 trajectoryVelocity;
  public float yLimit; //for later
  private float g;
  [Range(1, 30)]
  public float maxTimePressed;
  [Range(2, 30)]
  public int linecastResolution;
  public LayerMask canHit;

  // Internal variables for physics and stuff
  private float timePressed;
  private float trajectoryBouncer;
  private bool trajectoryBouncerDirection;

  [System.Serializable]
  public class IntEvent : UnityEvent<int> {}

  [Header("Laser Events")]
  [Space]
  public IntEvent OnShootEvent;

  #endregion

  #region UnityMethods
  // Awake is called when the script instance is being loaded
  void Awake()
  {
    timePressed = 0;
    trajectoryBouncer = 0f;
    trajectoryBouncerDirection = true;

    g = Mathf.Abs(Physics2D.gravity.y);
    trajectoryVelocity = new Vector2(0f, 0f);

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
      if (Input.GetButton("Fire1"))
      {
        timePressed += Time.deltaTime;

        if (trajectoryRenderer.gameObject.activeSelf == false)
        {
          trajectoryRenderer.gameObject.SetActive(true);
        }
        updateTrajectoryBouncer(Time.deltaTime);
        trajectoryVelocity = new Vector2(transform.right.x * launchForce * trajectoryBouncer, transform.up.y * launchForce * trajectoryBouncer);
        StartCoroutine(RenderBombTrajectory());
      }
      else if (Input.GetButtonUp("Fire1"))
      {
        ShootSmokeBomb();
        timePressed = 0f;
        trajectoryBouncer = 0f;
        trajectoryVelocity = new Vector2(0f, 0f);
        Vector3[] defaultPositions = new Vector3[2];
        defaultPositions[0] = new Vector3(0, 0, 0);
        defaultPositions[1] = new Vector3(0, 0, 0);
        trajectoryRenderer.SetPositions(defaultPositions);
        trajectoryRenderer.positionCount = 2;
        if (trajectoryRenderer.gameObject.activeSelf == true)
        {
          trajectoryRenderer.gameObject.SetActive(false);
        }
      }
    }
  }
  #endregion

  #region LanzagranadasMethods
  void ShootSmokeBomb()
  {
    if (ammo > 0)
    {
      GameObject bombIns = Instantiate(smokeBombPrefab, firePoint.position, firePoint.rotation);
      bombIns.GetComponent<Rigidbody2D>().velocity = (transform.up + transform.right) * launchForce * trajectoryBouncer;

      ammo--;
      OnShootEvent.Invoke(ammo);
    }
    else
    {
      // Should play some empty ammo sound
    }
  }
  #endregion

  #region trajectoryRenderer
  private void updateTrajectoryBouncer(float deltaTime)
  {
    if (trajectoryBouncerDirection == true)
    {
      if (trajectoryBouncer + deltaTime >= maxTimePressed)
      {
        trajectoryBouncerDirection = false;
        trajectoryBouncer -= deltaTime;
        return;
      }
      else
      {
        trajectoryBouncer += deltaTime;
      }
    }
    else
    {
      if (trajectoryBouncer - deltaTime <= 0)
      {
        trajectoryBouncerDirection = true;
        trajectoryBouncer += deltaTime;
        return;
      }
      else
      {
        trajectoryBouncer -= deltaTime;
      }
    }
    return;
  }

  private IEnumerator RenderBombTrajectory()
  {
    trajectoryRenderer.positionCount = resolution + 1;
    trajectoryRenderer.SetPositions(CalculateLineArray());
    yield return null;
  }

  private Vector3[] CalculateLineArray()
  {
    Vector3[] lineArray = new Vector3[resolution + 1];

    var lowestTimeValue = MaxTimeX() / resolution;

    lineArray[0] = new Vector3(firePoint.position.x, firePoint.position.y);
    for (int i = 1; i < lineArray.Length; i++)
    {
      var t = lowestTimeValue * i;
      lineArray[i] = CalculateLinePoint(t);
      Debug.Log(lineArray[i]);
    }

    return lineArray;
  }

  private Vector3 CalculateLinePoint(float t)
  {
    float x = trajectoryVelocity.x * t;
    float y = (trajectoryVelocity.y * t) - (g * Mathf.Pow(t, 2) / 2);
    return new Vector3(x + firePoint.position.x, y + firePoint.position.y);
  }

  private float MaxTimeY()
  {
    var v = trajectoryVelocity.y;
    var vv = v * v;

    var t = (v + Mathf.Sqrt(vv + 2 * g * (firePoint.position.y - yLimit))) / g;
    return t;
  }

  private float MaxTimeX()
  {
    var trajVelX = trajectoryVelocity.x;
    if (trajVelX == 0)
    {
      trajectoryVelocity.x = 000.1f;
      trajVelX = trajectoryVelocity.x;
    }

    var t = (HitPosition().x - firePoint.position.x) / trajVelX;
    return t;
  }

  private Vector2 HitPosition()
  {
    var lowestTimeValue = MaxTimeY() / linecastResolution;

    for (int i = 0; i < linecastResolution + 1; i++)
    {
      var t = lowestTimeValue * i;
      var tt = lowestTimeValue * (i + 1);

      var hit = Physics2D.Linecast(CalculateLinePoint(t), CalculateLinePoint(tt), canHit);

      if (hit)
        return hit.point;
    }

    return CalculateLinePoint(MaxTimeY());
  }
  #endregion
}
