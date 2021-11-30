using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyBladeAttack : MonoBehaviour
{
    public Animator animator;
    public bool isOn;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()

    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Beyblade Attack") && !isOn)
        {
            rb.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
            Debug.Log("Beblade YEet");
            isOn = true;   
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")//or tag
        {
            collision.GetComponent<playerHealth>().damage();
        }
    }
}
