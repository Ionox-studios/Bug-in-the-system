using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject bullet;
    public Rigidbody2D rb;
    public GameObject bulletEmitter;
    public float BulletForce;
    public float fireRate;
    private float nextSpawn;
    public AudioSource gunshot;
    public Animator anim;
    void Start()
    {
        nextSpawn = 0.0f;


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetLocation = target.transform.position;
        Vector2 selfLocation = rb.transform.position;
        Vector2 distance = selfLocation - targetLocation;
        float magnitude = distance.magnitude;
        if (magnitude < 10 && Time.time > nextSpawn & gameObject.GetComponent<AIPath>().enabled & !gameObject.GetComponent<enemySpotPlayer>().dying)
        {
            nextSpawn = Time.time + fireRate;
            Shoot();
            anim.SetBool("Attacking", true);
        }
        if(magnitude < 10)
        {
            anim.SetBool("Attacking", false);
        }

    }
    private void Shoot()
    {
        gunshot.Play();
        GameObject TempBullet;
        TempBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
        Rigidbody2D TempRigidBody;
        TempRigidBody = TempBullet.GetComponent<Rigidbody2D>();
        TempRigidBody.velocity= bulletEmitter.transform.right * BulletForce;
        Destroy(TempBullet, 10.0f);

    }
}
