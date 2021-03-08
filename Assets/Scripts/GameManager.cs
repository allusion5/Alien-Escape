using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 lastPlayerSighting;
    public float maxHealth;
    [HideInInspector] public float playerHealth;
    public bool gameActive = true;
    public bool isDetectedBySensor = false;
    public bool isDetectedByRobot = false;
    public AudioSource Source1;
    public AudioClip undetectedMusic;
    public AudioClip detectedMusic;
    public AudioClip gameOverMusic;
    public AudioClip winMusic;
    public AudioClip pickUpSound;
    public AudioClip detectedbyRobot;
    int counter = 0;//Helps keep the main background detected and undetected audio sounding right
    int losecounter = 0;//Helps Keep the game over audio sounding right
    int wincounter = 0;// Helps keep the win audio sounding right
    public Canvas PauseMenu;
    public Canvas GameOverMenu;
    public Canvas WinMenu;
    public Image redScreen;
    public Color damageOverlay;
    public bool isInvulnerable = false;
    public float invulnerableUntil;
    public float invulnerableDuration = 5f;
    public bool hasKeyCard;

    void Awake()
    {
        if (Instance == null) //Things werent working correctly on reset going from pause menu to main menu and then starting new game, so i did comment this section out. If you know how to make it work properly awesome. - Jordan
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerHealth = maxHealth;
        PauseMenu.enabled = false; // Pause menu canvas is off waiting for the player to press P to turn it on.
        GameOverMenu.enabled = false; // GameOverMenu is off waiting for players health to hit 0.
        WinMenu.enabled = false; // WinMenu is waiting to be triggered
        Time.timeScale = 1; // This is so that when you return from the main menu the game runs as if its a new game.
        counter = 0; // This is so that the background music can reset upon reloading from the main menu.
        losecounter = 0;
        wincounter = 0;
        redScreen.color = damageOverlay;
    }
    void Update()
    {
        damageOverlay.a = (5 - playerHealth) / 5;
        redScreen.color = damageOverlay;

        if (gameActive == true)
        {
            redScreen.enabled = true;
        }
        else
            redScreen.enabled = false;

        if (Time.time >= invulnerableUntil)
        {
            isInvulnerable = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PauseMenu.enabled == false)
            {
                PauseMenuUp();
            }
            else
            {
                PauseMenuDown();
            }
        }
        if ((isDetectedBySensor == true || isDetectedByRobot == true) && counter == 1 && gameActive == true)
        {
            if (counter == 1)
            {
                Source1.clip = detectedMusic;
                Source1.Play();
                counter += 1;
            }
        }
        if ((isDetectedBySensor == false && isDetectedByRobot == true) && counter == 2 && gameActive == true)
        {
            counter = 0;
        }
        if (isDetectedBySensor == false && isDetectedByRobot == false)
        {
            if (counter == 0)
            {
                Source1.clip = undetectedMusic;
                Source1.volume = 0.60f;
                Source1.Play();
                counter = +1;
            }
        }
        Die();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        PauseMenu.enabled = false;
        Source1.Stop();
        SceneManager.LoadScene("MenuScene");
    }

    void Die()
    {
        if (playerHealth <= 0)
        {
            gameActive = false;
            GameOverMenuUp();
        }
    }
    public void PauseMenuUp()
    {
        PauseMenu.enabled = true;
        gameActive = false;
        Time.timeScale = 0;
    }
    public void PauseMenuDown()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1;
    }
    public void GameOverMenuUp()
    {
        if (losecounter == 0)
        {
            gameActive = false;
            Source1.clip = gameOverMusic;
            Source1.Play();
            GameOverMenu.enabled = true;
            losecounter += 1;
        }
    }
    public void WinMenuUp()
    {
        if (wincounter == 0)
        {
            gameActive = false;
            Source1.clip = winMusic;
            Source1.Play();
            WinMenu.enabled = true;
            wincounter += 1;
        }
    }
    public void RobotDetectSound()
    {
        {
            if (gameActive == true)
                Source1.PlayOneShot(detectedbyRobot, 0.8f);
            else return;
        }
    }
    public void ItemPickUpSound()
    {
        Source1.PlayOneShot(pickUpSound, 0.8f);
    }

    //public void OpenPauseMenu()  Couldnt get this to work properly so i did it differently hope thats okay, if not thats why i left it in. - Jordan
    //{
    //gameActive = false;
    //PauseMenu.enabled = true;
    //Time.timeScale = 0;

    //if (Input.GetKeyDown(KeyCode.P))
    //{
    //PauseMenu.enabled = false;
    //gameActive = true;
    //Time.timeScale = 1;
    //}
    //}
}
