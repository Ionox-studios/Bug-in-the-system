using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class L1Music : MonoBehaviour
{
    static bool AudioBegin = false;
    void Awake()
    {
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "WinScene")
        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
        }
    }
}

