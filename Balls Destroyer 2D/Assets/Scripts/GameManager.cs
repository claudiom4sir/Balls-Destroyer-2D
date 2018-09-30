using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager singleton;
    
    [SerializeField] int numberOfBalls = 2;
    [SerializeField] GameObject player;

    bool gameOver = false;
    bool levelCompleted = false;
    bool gameInPause = false;
    bool gameStarted = false;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
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
        UIManager.singleton.GameOver();
        Debug.Log("Game Over");
    }

    public void LevelCompleted()
    {
        levelCompleted = true;
        Time.timeScale = 0f;
        UIManager.singleton.LevelCompleted();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        ScenesManager.singleton.ChangeScene("GameScene", 0f);
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public void PauseGame()
    {
        if (gameOver || levelCompleted)
            return;
        gameInPause = !gameInPause;
        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
        UIManager.singleton.PauseGame();
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public bool IsGameInPause()
    {
        return gameInPause;
    }

    public bool IsLevelCompleted()
    {
        return levelCompleted;
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }

    public void StartGame()
    {
        gameStarted = true;
        UIManager.singleton.StartGame();
        // this method takes in input the numer of balls that it has to spawns
        BallsManager.singleton.StartGame(numberOfBalls);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        ScenesManager.singleton.ChangeScene("ExitScene", 0f);
    }

}
