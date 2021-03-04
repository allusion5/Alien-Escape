using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 lastPlayerSighting;
    public float playerHealth;
    public bool gameActive = false;
    public Canvas PauseMenu;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return) && gameActive == true)
        {
            OpenPauseMenu();
        }
    }

    void Die()
    {
        if (playerHealth <= 0)
        {
            OpenPauseMenu();
        }
    }

    void OpenPauseMenu()
    {
        gameActive = false;
        PauseMenu.enabled = true;
        Time.timeScale = 0;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PauseMenu.enabled = false;
            gameActive = true;
            Time.timeScale = 1;
        }
    }
}
