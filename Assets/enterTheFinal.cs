using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterTheFinal : MonoBehaviour
{
    public gameManager gm;
    public SpecialdoorControllerCDC spdc;
    public GameObject killbot1;
    public GameObject killbot2;
    public bool hasFlippedThisTime = false;
    // Start is called before the first frame update
    void Start()
    {
        killbot1.SetActive(false);
        killbot2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player"& !hasFlippedThisTime)//or tag
        {
            gm.finalBattle = true;
            killbot1.SetActive(true);
            killbot2.SetActive(true);
            spdc.CloseDoor();
            hasFlippedThisTime = true;
            if (gameManager.firstEndConvo)
            {
                gameManager.secondEndConvo = true;
            }
            else
            {
                gameManager.firstEndConvo = true;
            }
            enabled = false;
        }
    }
}
