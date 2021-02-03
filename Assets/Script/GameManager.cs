using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public bool alive = true;
    private static GameManager _instance;

    public enum GameState
    {
        MainMenu,
        InGame,
        Pause,
        Death
    }
    private GameState _gameState;
    public GameState _GameState
    {
        get
        {
            return _gameState;
        }
    }
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        StateChange(GameState.MainMenu);
    }
    public void StateChange(GameState newState)
    {
        _gameState = newState;
        switch(_gameState)
        {
            case GameState.MainMenu:
                this.Menu();
                break;
            case GameState.InGame:
                this.Game();
                break;
            case GameState.Pause:
                this.Pause();
                break;
            case GameState.Death:
                this.Death();
                break;
        }
    }
    void Menu()
    {
        Time.timeScale = 0f;
    }
    void Pause()
    {
        alive = false;
        Time.timeScale = 0f;
    }
    void Game()
    {
        alive = true;
        Time.timeScale = 1f;
    }
    void Death()
    {
        alive = false;
        UIManager.Instance.EndGame(score);
    }
    public void UpdateScore()
    {
        _instance.score++;
        UIManager.Instance.UpdateScore(score);
    }
}
