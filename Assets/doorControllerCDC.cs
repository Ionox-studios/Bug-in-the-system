using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControllerCDC : MonoBehaviour
{
    public Animator anim;
    public Collider2D collider2d;
    public AudioSource open;
    public bool doorState;

    // Start is called before the first frame update
    void Start()
    {
        doorState = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {

        open.Play();
        Invoke("removeCollider", 1.6f);
        anim.SetBool("DoorOpen", true);

        



    }
    public void CloseDoor()
    {
        open.Play();
        Invoke("addCollider", 1.08f);
        anim.SetBool("DoorOpen", false);


    }
    private void removeCollider()
    {
        doorState = false;
        collider2d.enabled = false;
    }
    private void addCollider()
    {
        collider2d.enabled = true;
        doorState = true;

    }
}
