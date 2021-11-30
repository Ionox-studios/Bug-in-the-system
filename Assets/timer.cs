using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public float gameTime = 60f;
    public playerHealth ph;
    public gameManager gm;
    public bool finalBattle = false;
    public float finalFightTime = 30f;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time+ gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
        if (t <= 0 && !gm.finalBattle)
        {
            ph.damage();
        }
        if (t <= 0 && gm.finalBattle)
        {
            gm.WinGame();
        }
        if (!finalBattle & gm.finalBattle)
        {
            startTime = Time.time + finalFightTime;
            finalBattle = true;
            timerText.color = Color.red;
        }

    }
}
