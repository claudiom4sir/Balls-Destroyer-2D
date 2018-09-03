using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    [SerializeField] GameObject player;
    [SerializeField] GameObject[] ballsPrefabs;
    bool gameOver;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

}
