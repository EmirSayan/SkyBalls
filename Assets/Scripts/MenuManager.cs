using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public GameObject gamePausedCanvas;

    void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerControllerScript.gameOver == true)
        {
            gameOverCanvas.SetActive(true);
            gameCanvas.SetActive(false);
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {   
        Time.timeScale = 0;
        gameCanvas.SetActive(false);
        gamePausedCanvas.SetActive(true);
        
    }
    public void Rasume()
    {
        gamePausedCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1;
    }
}
