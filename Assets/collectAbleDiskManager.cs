using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class collectAbleDiskManager : MonoBehaviour
{
    public Image disk;
    public Image unlocked;
    public gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        disk.enabled = false;
        unlocked.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.PlayerHasdisk==true)
        {
            disk.enabled = true;
            unlocked.enabled = false;
        }
        if (gameManager.PlayerActivateServer==true)
        {
            disk.enabled = false;
            unlocked.enabled = true;

        }
    }
}
