using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] GameObject menu;
    [SerializeField] Text menuText;
    [SerializeField] Button startGameButton;

    public static UIManager singleton;

    GameManager gameManager;

    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
            Destroy(gameObject);
        gameManager = GameManager.singleton;
    }

    void Start()
    {
        menu.SetActive(false);
    }

    public void StartGame()
    {
        startGameButton.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        if (gameManager.IsGameInPause())
        {
            SetText("PAUSE");
            menu.SetActive(true);
            startGameButton.gameObject.SetActive(false);
        }
        else
        {
            menu.SetActive(false);
            if (!gameManager.IsGameStarted())
                startGameButton.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        SetText("GAME OVER");
        menu.SetActive(true);
    }

    public void LevelCompleted()
    {
        SetText("LEVEL COMPLETED");
        menu.SetActive(true);
    }

    void SetText(string text)
    {
        menuText.text = text;
    }

}
