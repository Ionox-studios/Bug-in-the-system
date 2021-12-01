using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Doublsb.Dialog;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;

    Vector2 movement;
    public PlayerInput playerInput;
    public Buginthesystem playerInputActions;
    public Camera cam;
    Vector2 mousePos;
    public AudioSource punch;
    public AudioSource grunt;
    public GameObject hitbox;
    private float despawnTime;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask interactableLayers;
    [SerializeField] private bool isGamepad;
    private Camera main;
    public DialogManager dialogManager;
    public gameManager gm;
    public Texture2D cursorArrow;
    public bool hasGun = false;
    public Animator animatorGun;
    public SpriteRenderer playerWithGun;
    public SpriteRenderer playerWithoutGun;
    public AudioSource gunShot;
    public float ammoCount = 0f;
    public Transform bulletEmitter;
    public float BulletForce = 20f;
    public GameObject bullet;
    public GameObject killbot;
    public playerHealth ph;
    public void Awake()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.Auto);

        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new Buginthesystem();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Move.performed += Move_performed;
        playerInputActions.Player.Look.performed += Look_performed;
        playerInputActions.Player.Fire.performed += Fire_performed;
        playerInputActions.Player.Interact.performed += Interact_performed;
        hitbox.SetActive(false);
        main = Camera.main;
        hasGun = false;
        playerWithoutGun.enabled = true;
        playerWithGun.enabled = false;
        animator.enabled = true;
        animatorGun.enabled = false;
        killbot.SetActive(false);
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        hitbox.SetActive(true);
        interact();
        despawnTime = Time.time + 0.25f;
    }

    private void Fire_performed(InputAction.CallbackContext context)
    {
        if (!hasGun)
        {
            animator.SetTrigger("Attack");
            grunt.Play();
            Invoke("Attack", .5f);
        }
        if (hasGun)
        {
            animatorGun.SetTrigger("Shooting");
            ammoCount = ammoCount - 1f;
  
            Invoke("Shoot", .9f);

        }
    }

    private void Look_performed(InputAction.CallbackContext context)
    {

        if (playerInput.currentControlScheme.Equals("Gamepad"))
        {
            Vector2 lookDir = context.ReadValue<Vector2>();
            float angle = -1f * Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;
        }
        else
        {
            Vector2 aim = context.ReadValue<Vector2>();
            Vector3 mouseWorldPosition = main.ScreenToWorldPoint(aim);
            Vector3 targetDirection = mouseWorldPosition - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        }
    }

    private void Move_performed(InputAction.CallbackContext context)
    {

    }



    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {



        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Bernie Longneck Headbutt")| animator.GetCurrentAnimatorStateInfo(0).IsName("GSS") | animator.GetCurrentAnimatorStateInfo(0).IsName("GSL")|| ph.dying)
        {
        }
        else
        {
            Vector2 movement = playerInputActions.Player.Move.ReadValue<Vector2>();
            mousePos = cam.ScreenToWorldPoint(playerInputActions.Player.Look.ReadValue<Vector2>());
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            Vector2 normMovedirection = transform.InverseTransformDirection(movement);
            if (!hasGun)
            {
                animator.SetFloat("RunSpeed", movement.magnitude);
                animator.SetFloat("AnimMoveX", normMovedirection.x);
                animator.SetFloat("AnimMoveY", normMovedirection.y);
            }
            if( hasGun)
            {
                animatorGun.SetFloat("RunSpeed", movement.magnitude);
            }
            if (despawnTime < Time.time)
            {
                hitbox.SetActive(false);
            }
        }



    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<enemySpotPlayer>().Die();
            punch.Play();

        }
       
    }
    void Shoot()
    {
        gunShot.Play();
        GameObject TempBullet;
        TempBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
        Rigidbody2D TempRigidBody;
        TempRigidBody = TempBullet.GetComponent<Rigidbody2D>();
        TempRigidBody.velocity = bulletEmitter.transform.right * BulletForce;
        Destroy(TempBullet, 10.0f);
        if (ammoCount == 0f)
        {
            hasGun = false;
            playerWithoutGun.enabled = true;
            playerWithGun.enabled = false;
            animator.enabled = true;
            animatorGun.enabled = false;
        }
    }
    void interact()
    {
        
        Collider2D[] interactables = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, interactableLayers);
        foreach (Collider2D interactable in interactables)
        {
            Debug.Log(interactable.gameObject.name);
            if (interactable.gameObject.tag == "Door")
            {
                if (interactable.GetComponent<doorControllerCDC>().doorState == true)
                {
                    interactable.GetComponent<doorControllerCDC>().OpenDoor();

                }
                if (interactable.GetComponent<doorControllerCDC>().doorState == false)
                {
                    interactable.GetComponent<doorControllerCDC>().CloseDoor();
                }
            }
            if (interactable.gameObject.tag == "SpecialDoor")
            {
                interactable.GetComponent<SpecialdoorControllerCDC>().OpenDoor();
            }
                if (interactable.gameObject.tag == "Disk")
            {
                gameManager.PlayerHasdisk = true;
                Destroy(interactable.gameObject);
            }
            if(interactable.gameObject.tag=="Server")
            {
                if(gameManager.PlayerHasdisk==true)
                {
                    gameManager.PlayerActivateServer = true;
                    killbot.SetActive(true);
                }
            }
            if (interactable.gameObject.name =="Computer 1")
            {
                gm.computer1 = true;
            }
            if (interactable.gameObject.name == "Computer 2")
            {
                gm.computer2 = true;
            }
            if (interactable.gameObject.name == "Computer 3")
            {
                gm.computer3 = true;
            }
            if (interactable.gameObject.name == "Computer 4")
            {
                gm.computer4 = true;
            }
            if (interactable.gameObject.name == "Computer 5")
            {
                gm.computer5 = true;
            }
            if (interactable.gameObject.name == "Computer 6")
            {
                gm.computer6 = true;
            }
            if( interactable.gameObject.name == "Watercooler")
            {
                if (gm.waterGuyConvo == false)
                {
                    gameManager.WCGuyConvos = gameManager.WCGuyConvos + 1;
                    gm.waterGuyConvo = true;
                }
            }

        }
    }
    private void Click_performed(InputAction.CallbackContext obj)
    {

        dialogManager.Click_Window();
    }
    public void OnTurnOn()
    {
        playerInput.SwitchCurrentActionMap("Player");
        playerInputActions.UI.Disable();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Move.performed += Move_performed;
        playerInputActions.Player.Look.performed += Look_performed;
        playerInputActions.Player.Fire.performed += Fire_performed;
        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.UI.Click.performed -= Click_performed;

    }
    public void OnTurnOff()
    {
        
        playerInputActions.Player.Move.performed -= Move_performed;
        playerInputActions.Player.Look.performed -= Look_performed;
        playerInputActions.Player.Fire.performed -= Fire_performed;
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.Disable();
        playerInput.SwitchCurrentActionMap("UI");
        playerInputActions.UI.Enable();
        playerInputActions.UI.Click.performed += Click_performed;

    }
    public void pickUpGun()
    {
        hasGun = true;
        ammoCount = 3f;
        playerWithoutGun.enabled = false;
        playerWithGun.enabled = true;
        animator.enabled = false;
        animatorGun.enabled = true;
    }



}
