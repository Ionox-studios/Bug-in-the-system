using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;


    public void setHealth(float health)
    {

        if (health == 3f)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }
        if (health == 2f)
        {
            heart1.enabled = false;
            heart2.enabled = true;
            heart3.enabled = true;
        }
        if (health == 1f)
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = true;
        }
        if (health == 0f)
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;
        }
    }
}
