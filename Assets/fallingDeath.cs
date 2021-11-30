using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingDeath : MonoBehaviour
{
    public Animator player;
    public Animator playerWithGun;
    public playerHealth ph;
    public PlayerMovement pm;
    public gameManager gm;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "Death")//or tag
        {
            Debug.Log(collision.transform.tag);
            ph.dying = true;
            gm.EndGame();
            if (pm.hasGun)
            {
                playerWithGun.Play("Bernie Fall Death");
                
            }
            if (!pm.hasGun)
            {
                player.Play("Bernie Fall Death");

            }


        }
        
    }
}
