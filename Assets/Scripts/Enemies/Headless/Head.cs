using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour, Enemy
{
    private Transform target;
    private Transform master;
    private bool hitTarget;
    private float timeStart;
    private float maxFlightDuration = 4;
    private CircleCollider2D collider;
    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem particleSystem;

    void Start()
    {
        timeStart = Time.time;
        collider = GetComponent<CircleCollider2D>();
    }

    public void TakeDamage(int damage)
    {
        PlayEffect();
        master.GetComponent<HeadlessController>()?.Die();
    }

    public void PlayEffect()
    {
        Instantiate(particleSystem).transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (timeStart + maxFlightDuration <= Time.time)
        {
            hitTarget = true;
            
       
        }
        transform.Rotate(0, 0, 500 * Time.deltaTime);
        Move();
        if (CheckIfHeadReturnedToMaster())
        {
            master.GetComponent<HeadlessController>()?.ReturnHead(gameObject);
           
        }
    }

    public void ThrowAtTarget(Transform target, Transform master)
    {
        this.target = target;
        this.master = master;
    }

    bool CheckIfHeadReturnedToMaster()
    {
        return hitTarget && (Vector2.Distance(master.position + new Vector3(0, .1f, 0), transform.position) <= 0.01f && hitTarget);
    }

    void PlayEatSound()
    {
        var audioManager = AudioManager.instance;
        audioManager.PlaySound("HeadlessBiteSFX", false);
    }
    void Move()
    {
        if (target == null) return;
        if (Vector2.Distance(target.position, transform.position) <= .5f) {
            hitTarget = true;
            target.GetComponent<PlayerController>()?.OnDecrementLife();
            PlayEatSound();
        }
        transform.position = hitTarget ? Vector2.MoveTowards(transform.position, master.position + new Vector3(0, .1f, 0), Time.deltaTime *speed) : Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }


}
