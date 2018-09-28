using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager singleton;

    [SerializeField] int numberOfBalls = 2;
    [SerializeField] GameObject player;

    // used to call a set of methods when game will be over when the level will be completed
    public delegate void GameOverAction();
    public event GameOverAction OnGameOver;

    // used to call a set of methods when game will be over when the level will be completed
    public delegate void LevelCompletedAction();
    public event GameOverAction OnLevelCompleted;

    bool gameOver = false;
    bool levelCompleted = false;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Update() // used only to test on pc
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartGame();
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
        OnGameOver();
        Debug.Log("Game Over");
    }

    public void LevelCompleted()
    {
        levelCompleted = true;
        Time.timeScale = 0f;
        OnLevelCompleted();
        Debug.Log("Level completed");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public bool IsLevelCompleted()
    {
        return levelCompleted;
    }

    public void StartGame()
    {
        // this method takes in input the numer of balls that it has to spawns
        BallsManager.singleton.StartGame(numberOfBalls);
    }

    public void Exit()
    {
        SceneManager.LoadScene("ExitScene");
    }

}
