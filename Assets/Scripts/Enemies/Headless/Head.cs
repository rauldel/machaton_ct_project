using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    private Transform target;
    private Transform master;
    private bool hitTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (CheckIfHeadReturnedToMaster())
        {
            master.GetComponent<Headless>()?.ReturnHead();
            Destroy(gameObject);
        }
    }

    public void ThrowAtTarget(Transform target, Transform master)
    {
        this.target = target;
        this.master = master;
    }

    bool CheckIfHeadReturnedToMaster()
    {
        return (Vector2.Distance(master.position + new Vector3(0, .1f, 0), transform.position) <= 0.01f && hitTarget);
    }
    void Move()
    {
        Debug.Log(target);
        if (target == null) return;
        if (Vector2.Distance(target.position, transform.position) <= 0.1f) {
            hitTarget = true;
        }
        transform.position = hitTarget ? Vector2.MoveTowards(transform.position, master.position + new Vector3(0, .1f, 0), Time.deltaTime *3f) : Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * 3f);
    }
}
