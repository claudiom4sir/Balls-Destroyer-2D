using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    [SerializeField] GameObject player;
    [SerializeField] GameObject[] ballsPrefabs;
    [SerializeField] GameObject firstBallPrefabs;
    [SerializeField] BallsSpawner ballsSpawner;
    bool gameOver;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Update() // used only for test on pc
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartGame();
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public GameObject GetFirstBallPrefabs()
    {
        return firstBallPrefabs;
    }

    public void StartGame()
    {
        // CreateBall gets in input the number of balls that it has to spawn 
        ballsSpawner.CreateBall(1);
    }

    

}
