using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.UI;
public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    static public bool PlayerHasdisk = false;
    static public bool PlayerActivateServer = false;
    static public int loopNumber = 0;
    static public bool inServerRoom=false;
    static public bool inServerRoomwithDisk= false;
    static public bool firstEndConvo = false;
    static public bool secondEndConvo = false;
    public bool computer1 = false;
    public bool computer2 = false;
    public bool computer3 = false;
    public bool computer4 = false;
    public bool computer5 = false;
    public bool computer6 = false;
    public bool finalBattle = false;
    public RawImage vp;

    Vector2 movement;
   
    

    private Buginthesystem playerInputActions;

    private float despawnTime;
    public void Awake()
    {
        playerInputActions = new Buginthesystem();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Quit.performed += Quit_performed;
        vp.enabled = false;
    }

    private void Quit_performed(InputAction.CallbackContext context)
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    // Start is called before the first frame update
    public void EndGame()
    {
        if(gameHasEnded==false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            
            Invoke("Restart", restartDelay);
        }    
    }
    public void WinGame()
    {
        Invoke("win", 2f);
    }   

        void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loopNumber += 1;
        vp.enabled = false;
       
    }
    void win()
    {
        SceneManager.LoadScene("WinScene");
    }
    void playerGetsDisk()
    {
        PlayerHasdisk = true;
    }
    void playerActivatesServer()
    {
        PlayerActivateServer = true;
    }
    public class QuitManager : MonoBehaviour
    {

        
    }
}
