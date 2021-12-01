using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
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

        if (collision.transform.tag == "Player")//or tag
        {
            collision.GetComponent<playerHealth>().damage();

            

            Destroy(gameObject);


        }
        else if (collision.transform.name == "finalRoomTrigger")//or tag
        { 
        }
        else if (collision.transform.tag == "Door")//or tag
        {
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
