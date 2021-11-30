using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemySpotPlayer : MonoBehaviour
{
    public float rng;
    public float fov;
    public float distanceToPlayer;
    private float angle;
    public Transform playerPosition;
    private bool playerInRange;
    AIPath aipath;
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;
    public Animator animator;
    public AudioSource notice;
    public AudioSource gunshot;
    public bool dying;
    public Transform BulletEmitter;
    public GameObject item;
    public AudioSource die;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    private bool walkBack;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<AIPath>() != null)
        {
            gameObject.GetComponent<AIPath>().enabled = false;
        }
        if (waypoints.Length != 0)
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }
        playerInRange = false;
        walkBack = false;
        dying = false;




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInRange == false && waypoints.Length!=0& !dying)
        {
            Move();
        }
        distanceToPlayer = Vector3.Distance((Vector2)transform.position, (Vector2)playerPosition.position);

        angle = Vector2.Angle(transform.up, playerPosition.position - transform.position);
        if (distanceToPlayer < rng & !dying)  //range = known float
        {
            
            if (angle < fov * 0.5f) //fov = know float
            {

                playerInRange = true;
                string objectName = gameObject.name;
                if (gameObject.GetComponent<AIPath>() != null )
                {
                    if (objectName.Contains("Grunt") & gameObject.GetComponent<AIPath>().enabled == false)
                    {
                        gameObject.GetComponent<AIPath>().enabled = true;
                        notice.Play();
                        animator.SetBool("inPursuit",true);
                    }
                }
                if (objectName.Contains("Beyblade"))
                {
                    animator.SetTrigger("Attack");
                }
            }

        }
        if (gameObject.GetComponent<AIPath>() != null)
        {
            if (gameObject.GetComponent<AIPath>().enabled & !dying)
            {
                rotateToEnemy();
            }

        }
    }
    private void Move()
    {

            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);
            transform.up = waypoints[waypointIndex].transform.position - transform.position;
            Vector3 targetPos = waypoints[waypointIndex].transform.position;
            Vector3 thisPos = transform.position;
            targetPos.x = targetPos.x - thisPos.x;
            targetPos.y = targetPos.y - thisPos.y;
            float angle2 = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
            Quaternion safeRotation = Quaternion.Euler(new Vector3(0, 0, angle2 - 90f));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, safeRotation, 5f * Time.deltaTime);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                if (walkBack == false)
                {
                    waypointIndex += 1;
                }
                if (walkBack == true)
                {
                    waypointIndex -= 1;
                }
            }


            if (waypointIndex == waypoints.Length)
            {
                walkBack = true;
                waypointIndex -= 1;
            }
            if (waypointIndex == 0)
            {
                walkBack = false;
            }
        
    }
    private void rotateToEnemy()
    {
        Vector3 targetPos;
        targetPos.x = playerPosition.position.x - BulletEmitter.position.x;
        targetPos.y = playerPosition.position.y - BulletEmitter.position.y;
        float angle2 = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        Quaternion safeRotation = Quaternion.Euler(new Vector3(0, 0, angle2-90f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, safeRotation, 100f * Time.deltaTime);
    }
    public void Die()
    {
        die.Play();
        dying = true;
        animator.SetTrigger("Die");
        Invoke("dropGun", .7f);
        Invoke("selfDisable", .7f);
    }
    void selfDisable()
    {
        Destroy(gameObject);
    }
    void dropGun()
    {
        if (item != null)
        {
            Instantiate(item, transform.position + new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }
}
    
