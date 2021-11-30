using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletTracker : MonoBehaviour
{
    public Image bullet1;
    public Image bullet2;
    public Image bullet3;
    public PlayerMovement ps;
    public float ammoCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount = ps.ammoCount;
        if (ammoCount == 3f)
        {
            bullet1.enabled = true;
            bullet2.enabled = true;
            bullet3.enabled = true;
        }
        if (ammoCount == 2f)
        {
            bullet1.enabled = false;
            bullet2.enabled = true;
            bullet3.enabled = true;
        }
        if (ammoCount == 1f)
        { 
            bullet1.enabled = false;
            bullet2.enabled = false;
            bullet3.enabled = true;
        }
        if (ammoCount == 0f)
        {
            bullet1.enabled = false;
            bullet2.enabled = false;
            bullet3.enabled = false;
        }
    }
}
