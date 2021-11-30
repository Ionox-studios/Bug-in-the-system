using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float hitPoints;
    public float invulnTimer;
    private float currentTime;
    public AudioSource injured;
    public SpriteRenderer m_SpriteRenderer;
    public Animator anim;
    public Animator gunAnim;
    public SpriteRenderer gunSprite;
    public HealthBar healthbar;
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 3f;
        invulnTimer = 1f;
        currentTime = 0f;
        healthbar.setHealth(hitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        


        if (currentTime < Time.time)
        {
            if (!pm.hasGun)
            {
                Color tmp = m_SpriteRenderer.color;
                tmp.a = 255f;
                m_SpriteRenderer.color = tmp;
            }
            if(pm.hasGun)
            {
                Color tmp = gunSprite.color;
                tmp.a = 255f;
                gunSprite.color = tmp;
            }
        }
    }
    public void damage()
    {
        if (hitPoints > 0)
        {
            if (currentTime < Time.time)
            {
                hitPoints = hitPoints - 1f;
                healthbar.setHealth(hitPoints);
                currentTime = Time.time + invulnTimer;
                if (hitPoints > 0)
                {
                    if (!pm.hasGun)
                    {
                        injured.Play();
                        Color tmp = gunSprite.color;
                        tmp.a = 0.5f;
                        gunSprite.color = tmp;
                        anim.Play("BernieOuchie");
                    }
                    if (pm.hasGun)
                    {
                        injured.Play();
                        Color tmp = gunSprite.color;
                        tmp.a = 0.5f;
                        gunSprite.color = tmp;
                        gunAnim.Play("BernieOuchie");
                    }


                }
            }
            if (hitPoints <= 0)
            {
                if (!pm.hasGun)
                {
                    Color tmp = m_SpriteRenderer.color;
                    tmp.a = 255f;
                    m_SpriteRenderer.color = tmp;
                    anim.Play("DeathAnimationMC");
                }
                if (pm.hasGun)
                {
                    Color tmp = gunSprite.color;
                    tmp.a = 255f;
                    gunSprite.color = tmp;
                    gunAnim.Play("Bernie Death");
                }
                FindObjectOfType<gameManager>().EndGame();
            }
        }
    }
}
