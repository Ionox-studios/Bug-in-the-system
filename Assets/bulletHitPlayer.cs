using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHitPlayer : MonoBehaviour
{
    public GameObject bullet;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something");
        Debug.Log(collision.transform.name);

        if (collision.transform.tag == "Enemy")//or tag
        {
            collision.GetComponent<enemySpotPlayer>().Die();
            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
