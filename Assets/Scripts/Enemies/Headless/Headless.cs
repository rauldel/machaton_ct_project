using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HEADLESS_STATE { WALKING, THROWING, HEADLESS };
public enum MOVE_DIRECTION { LEFT, RIGHT };

public class Headless : MonoBehaviour
{
    [SerializeField] private Transform player;

    private MOVE_DIRECTION moveDirection;
    

    private MOVE_DIRECTION MoveDirection
    {
        get { return moveDirection; }
        set
        {
            moveDirection = value;
            if (value == MOVE_DIRECTION.LEFT)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

    }

    private HEADLESS_STATE currentState = HEADLESS_STATE.WALKING;
    private float scale = 1;
    [SerializeField] private Head headPrefab;
    private Head head;
    [SerializeField] private float attackDistance = 10f;


    private BoxCollider2D collider;

    void Awake()
    {

        collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        MoveDirection = MOVE_DIRECTION.RIGHT;
    }

    void Update()
    {

        Move();
        Attack();
    }

    bool CheckIfPlayerIsAtAttackDistance()
    {
        return (Vector2.Distance(transform.position, player.position) <= attackDistance);


    }

    void Attack()
    {
       



        if (currentState != HEADLESS_STATE.THROWING && currentState != HEADLESS_STATE.HEADLESS && CheckIfPlayerIsAtAttackDistance())
        {
            if (player.position.x <= transform.position.x)
            {


                MoveDirection = MOVE_DIRECTION.LEFT;
            }
            else
            {

                MoveDirection = MOVE_DIRECTION.RIGHT;
            }
            var anim = GetComponent<Animator>();
            anim.SetBool("isThrowing", true);
            currentState = HEADLESS_STATE.THROWING;
        }



    }

    public void SpawnProjectile()
    {

        currentState = HEADLESS_STATE.HEADLESS;
        head = Instantiate(headPrefab);
        head.transform.position = transform.position + new Vector3(-.5f, .5f, 0);
        head.ThrowAtTarget(player, transform);


    }

    public void ReturnHead()
    {
        currentState = HEADLESS_STATE.WALKING;
        var anim = GetComponent<Animator>();
        anim.SetTrigger("isWalking");
    }

    void Move()
    {
        if (currentState == HEADLESS_STATE.THROWING) return;
    
        if (MoveDirection == MOVE_DIRECTION.RIGHT)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
         
        }
        else
        {
         
            transform.Translate(Vector2.left * Time.deltaTime);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag != "Constraint") return;
        
        if (MoveDirection == MOVE_DIRECTION.RIGHT)
        {
            MoveDirection = MOVE_DIRECTION.LEFT;
        }
        else
        {
            MoveDirection = MOVE_DIRECTION.RIGHT;

        }
        Debug.Log(collision.gameObject.tag + " " + MoveDirection);
    }
}
