using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyAttackKillbot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject bullet;
    public GameObject bulletEmitter;
    public float BulletForce;
    public float fireRate;
    private float nextSpawn;
    public AudioSource gunshot;
    public bool AttackBool;

    void Start()
    {
        nextSpawn = 0.0f;
        AttackBool = false;

    }

    // Update is called once per frame
    void Update()
    {
            if (AttackBool && Time.time > nextSpawn)
        {
            
            nextSpawn = Time.time + fireRate;
            Shoot();
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
