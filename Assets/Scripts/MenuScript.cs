using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject ManagerofGame;
    void Start()
    {
        ManagerofGame = GameObject.Find("GameManager");
    }

    void Update()
    {
        if(ManagerofGame != null) 
        {
            Destroy(ManagerofGame);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame ()
    {
        Application.Quit();
    }
}