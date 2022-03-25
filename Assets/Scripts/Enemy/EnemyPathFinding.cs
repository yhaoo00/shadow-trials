using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyPathFinding: MonoBehaviour
{
    public static EnemyPathFinding Instance;

    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private LayerMask layerMask;
    
    private enum AIState
    {
        Roaming,
        Chase,
    }

    public Transform target;
    public float speed = 400f;
    public float nextWayPointDist = 3f;
    private Vector3 roamPosition;
    private AIState state;
    private Animator anim;
    public float viewDistance = 7f;
    private Vector2 force;

    Path path;
    int currentWayPoint = 0;
    bool reachEndPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    private void Awake()
    {
        state = AIState.Roaming;
    }

    private void Start()
    {
        Instance = this;
        
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        roamPosition = GetRoamingPosition();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    private Vector3 GetRoamingPosition()
    {
        return (Vector3)rb.position + GetRandomDirection() * Random.Range(10f, 70f);
    }

    private static Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    void UpdatePath()
    {
        switch (state)
        {
            default:
            case AIState.Roaming:
                if (seeker.IsDone()) seeker.StartPath(rb.position, roamPosition, OnPathComplete);
                FindTarget();
                break;

            case AIState.Chase:
                if (seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPathComplete);

                if (Vector3.Distance(transform.position, target.position) > (viewDistance + viewDistance))
                {
                    state = AIState.Roaming;
                }
                break;
        }  
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    private void FixedUpdate()
    {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetViewDistance(viewDistance);

        if (path == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachEndPath = true;
            roamPosition = GetRoamingPosition();
            return;
        }
        else
        {
            reachEndPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        force = direction * speed * Time.fixedDeltaTime;

        if (direction != Vector2.zero)
        {
            //rb.MovePosition(transform.position + (Vector3)direction.normalized * speed * Time.fixedDeltaTime);
            rb.AddForce(force);

            anim.SetFloat("moveX", direction.x);
            anim.SetFloat("moveY", direction.y);
            anim.SetBool("isMoving", true);
        }
        else
            anim.SetBool("isMoving", false);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDist)
        {
            currentWayPoint++;
        }
    }

    private void FindTarget()
    {
        if (Vector3.Distance(transform.position, target.position) < viewDistance)
        {
            Vector3 dirToPlayer = (target.position - transform.position).normalized;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, dirToPlayer, viewDistance, layerMask);

            if (raycastHit2D.collider != null)
            {
                //Debug.Log("Enemy collide: " + raycastHit2D.collider.gameObject.name);
                if (raycastHit2D.collider.tag == "Player")
                {
                    state = AIState.Chase;
                }
                else
                {
                    //pass
                }
            }
        }
    }
}
