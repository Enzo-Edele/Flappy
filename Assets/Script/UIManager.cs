using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreDisplay;
    public Text scoreFinal;
    private static UIManager _instance;
    public GameObject endMenuUI;
    public GameObject startMenuUI;
    public GameObject pauseMenuUI;
    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    public void UpdateScore(int score)
    {
        scoreDisplay.text = "Score : " + score;
    }
    public void EndGame(int score)
    {
        if (scoreDisplay != null)
        {
            scoreDisplay.text = " ";
        }
        if (endMenuUI != null)
        {
            endMenuUI.SetActive(true);
        }
        if (scoreFinal != null)
        {
            scoreFinal.text = "Score : " + score;
        }
    }
    public void Pause()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
    }
    public void Resume()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        GameManager.Instance.StateChange(GameManager.GameState.InGame);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
