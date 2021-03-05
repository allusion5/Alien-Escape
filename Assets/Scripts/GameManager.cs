using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 lastPlayerSighting;
    public float playerHealth;
    public bool gameActive = true;
    public bool isDetected = false;
    public AudioSource Source1;
    public AudioClip undetectedMusic;
    public AudioClip detectedMusic;
    public AudioClip gameOverMusic;
    int counter = 0;
    public Canvas PauseMenu;
    public Canvas GameOverMenu;

    void Awake()
    {
        PauseMenu.enabled = false; // Pause menu canvas is off waiting for the player to press P to turn it on.
        GameOverMenu.enabled = false; // GameOverMenu is off waiting for players health to hit 0.
        Time.timeScale = 1; // This is so that when you return from the main menu the game runs as if its a new game.
        counter = 0; // This is so that the background music can reset upon reloading from the main menu.

       // if (Instance == null) Things werent working correctly on reset going from pause menu to main menu and then starting new game, so i did comment this section out. If you know how to make it work properly awesome. - Jordan
       // {
            //Instance = this;
           // DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
            //Destroy(gameObject);
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseMenuUp();
        }
        if (isDetected == true && counter == 1)
        {
            if(counter == 1)
            {
                Source1.clip = detectedMusic;
                Source1.Play();
                counter +=1 ;
            }
        }
        if (isDetected == false && counter == 2 )
        {
            counter = 0;
        }
        if(isDetected == false)
        {
            if(counter ==0 )
            {
            Source1.clip = undetectedMusic;
            Source1.volume = 0.60f;
            Source1.Play();
            counter =+ 1;
            }
        }
        
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
            GameOverMenuUp();
        }
    }
    public void PauseMenuUp()
    {
        PauseMenu.enabled = true;
        Time.timeScale = 0;
    }
    public void PauseMenuDown()
    {
        PauseMenu.enabled = false;
        Time.timeScale = 1;
    }
    public void GameOverMenuUp()
    {
        Source1.clip = gameOverMusic;
        Source1.Play();
        GameOverMenu.enabled = true;
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
