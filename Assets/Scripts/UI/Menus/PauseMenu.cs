using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject[] players;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        foreach (GameObject player in players)
        {
            if(player.name == "Takashi")
            {
                player.GetComponent<TakashiController>().enabled = true;
                player.GetComponent<TakashiCombatController>().enabled = true;
            }
            else if(player.name == "Gorm")
            {
                player.GetComponent<GormController>().enabled = true;
                player.GetComponent<GormCombatController>().enabled = true;
            }   
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        foreach (GameObject player in players)
        {
            if(player.name == "Takashi")
            {
                player.GetComponent<TakashiController>().enabled = false;
                player.GetComponent<TakashiCombatController>().enabled = false;
            }
            else if(player.name == "Gorm")
            {
                player.GetComponent<GormController>().enabled = false;
                player.GetComponent<GormCombatController>().enabled = false;
            }   
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit :(");
        Application.Quit();
    }
}
