using UnityEngine;

public enum MOVE_DIRECTION
{
    LEFT,
    RIGHT
}

public class HeadlessController : MonoBehaviour
{
    [SerializeField] private int healthPoints = 10;
    [SerializeField] private int lootCoins = 10;
    [SerializeField] private Transform platform;
    [SerializeField] private float attackDistance = 6;
    [SerializeField] private Head headPrefab;
    [SerializeField] private float zombieSpeed = 1;
    [SerializeField] public float minAudioDistance = 1f;
    [SerializeField] public float maxAudioDistance = 25f;
    [SerializeField] [Range(0, 1)] public float headlessMaxVolume = 0.75f;
    [SerializeField] private ParticleSystem particleSystem;

    private Animator animator;
    private MOVE_DIRECTION directionToPlayer;
    private Head head;
    private bool headIsSpawned = false;
    private AudioSource headlessAudioSource;
    private bool isHeadless;
    private bool isWalking;
    private float lastChangedDirection;
    private MOVE_DIRECTION moveDirection;
    private float platformLeftBound;
    private float platformRightBound;
    private Transform player;
    private bool playerIsInAttackRange;

    private bool IsWalking
    {
        get => isWalking;


        set
        {
            isWalking = value;
            animator.SetBool("isWalking", value);
        }
    }

    private bool IsHeadless
    {
        get => isHeadless;

        set
        {
            isHeadless = value;
            animator.SetBool("isHeadless", value);
        }
    }

    private MOVE_DIRECTION MoveDirection
    {
        get => moveDirection;
        set
        {
            moveDirection = value;
            transform.localScale = value == MOVE_DIRECTION.LEFT ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lastChangedDirection = Time.time;
        player = GameObject.Find("Player")?.transform;
    }

    private void Start()
    {
        IsWalking = true;
        IsHeadless = false;
        PlaceSelfOnStartPosition(platform);
        MoveDirection = MOVE_DIRECTION.LEFT;
        headlessAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Attack();
        Move();
        HandleHeadlessSound(Vector2.Distance(transform.position, player.position));
    }

    public void TakeDamage(int damageAmount)
    {
        if (healthPoints - damageAmount <= 0)
        {
            player.GetComponent<PlayerController>().OnIncreaseCoin(lootCoins);
            Die();
        }
        else
        {
            healthPoints -= damageAmount;
        }
    }

    public void Die()
    {
        var audioManager = AudioManager.instance;
        audioManager.PlaySound("HeadlessDeathSFX", false);
        Instantiate(particleSystem).transform.position = transform.position;
        if (head)
        {
            head.PlayEffect();
            Destroy(head.gameObject);
        }

        Destroy(gameObject);
    }


    private bool CheckIfPlayerIsAtAttackDistance()
    {
        return Vector2.Distance(transform.position, player.position) <= attackDistance;
    }

    private MOVE_DIRECTION GetCurrentDirectionToPlayer()
    {
        return player.position.x <= transform.position.x ? MOVE_DIRECTION.LEFT : MOVE_DIRECTION.RIGHT;
    }

    private void Attack()
    {
        if (CheckIfPlayerIsAtAttackDistance() && !IsHeadless && !head)
        {
            IsHeadless = true;
            animator.SetTrigger("throwHead");
        }
    }

    // this method is called by the animation trigger
    private void SpawnProjectile()
    {
        if (head) return;

        head = Instantiate(headPrefab);
        head.transform.position = transform.position + new Vector3(-.5f, .5f, 0);
        head.ThrowAtTarget(player, transform);
    }

    public void ReturnHead(GameObject head)
    {
        IsHeadless = false;
        Destroy(head.gameObject);
    }

    private void Patrol()
    {
        var vector = MoveDirection == MOVE_DIRECTION.RIGHT ? Vector2.right : Vector2.left;


        if (transform.position.x + vector.x * Time.deltaTime < platformLeftBound)
        {
            MoveDirection = MOVE_DIRECTION.RIGHT;
            vector = Vector2.right;
        }

        if (transform.position.x + vector.x * Time.deltaTime > platformRightBound)
        {
            MoveDirection = MOVE_DIRECTION.LEFT;
            vector = Vector2.left;
        }

        if (!IsWalking) IsWalking = true;

        transform.Translate(vector * Time.deltaTime * zombieSpeed);
    }


    private void FollowEnemy()
    {
        var directionToPlayer = GetCurrentDirectionToPlayer();
        var vector = directionToPlayer == MOVE_DIRECTION.RIGHT ? Vector2.right : Vector2.left;
        if (CheckIfCanChangeDirectionToPlayer()) MoveDirection = directionToPlayer;

        if (transform.position.x + vector.x * Time.deltaTime < platformLeftBound ||
            transform.position.x + vector.x * Time.deltaTime > platformRightBound)
        {
            if (IsWalking) IsWalking = false;
        }
        else
        {
            transform.Translate(vector * Time.deltaTime * zombieSpeed);
            if (!IsWalking) IsWalking = true;
        }
    }

    private void Move()
    {
        if (IsHeadless)
        {
            FollowEnemy();
            return;
        }

        Patrol();
    }

    // this method is used to prevent headless from constant changing direction if player is on top of him, which causes awkward visual effect
    private bool CheckIfCanChangeDirectionToPlayer()
    {
        if (lastChangedDirection + .3f < Time.time)
        {
            lastChangedDirection = Time.time;
            return true;
        }

        return false;
    }

    private void PlaceSelfOnStartPosition(Transform platform)
    {
        Debug.Log(platform + "platform");
        var platformCollider = platform.GetComponent<BoxCollider2D>();
        var headlessCollider = GetComponent<BoxCollider2D>();
        platformLeftBound = platformCollider.bounds.min.x + headlessCollider.size.x / 2;
        platformRightBound = platformCollider.bounds.max.x - headlessCollider.size.x / 2;
        transform.position = new Vector2(platformCollider.bounds.center.x,
            platformCollider.bounds.max.y + headlessCollider.size.y / 2);
    }

    private void HandleHeadlessSound(float playerDistance)
    {
        if (playerDistance < minAudioDistance)
            headlessAudioSource.volume = headlessMaxVolume;
        else if (playerDistance > maxAudioDistance)
            headlessAudioSource.volume = 0;
        else
            headlessAudioSource.volume = headlessMaxVolume -
                                         (playerDistance - minAudioDistance) / (maxAudioDistance - minAudioDistance);

        if (GameSceneController.GameIsOver || GameSceneController.GameIsPaused || GameSceneController.StoreIsOpen)
            headlessAudioSource.Pause();
        else
            headlessAudioSource.UnPause();
    }
}