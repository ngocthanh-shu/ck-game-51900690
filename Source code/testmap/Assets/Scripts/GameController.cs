using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    // private string sceneHasPlayer;

    [SerializeField]
    private Button resumeGame;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumeGame());
    }

    // public void StartGame()
    // {
        // Time.timeScale = 1f;
        // PlayerData data = SaveSystem.LoadPlayer();
        // sceneHasPlayer = data.sceneHasPlayer;

        // SceneManager.LoadScene(1);
    // }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHome()
    {
        // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SavePlayerGame(); //lưu lại sau khi về màn hình chính
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    public void QueQuitGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void DontQuitGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(false);
    }
}