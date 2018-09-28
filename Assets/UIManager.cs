using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] GameObject menu;
    [SerializeField] Text menuText;

    public static UIManager singleton;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        menu.SetActive(false);
        GameManager.singleton.OnGameOver += GameOver;
        GameManager.singleton.OnLevelCompleted += LevelCompleted;
    }

    void GameOver()
    {
        SetText("GAME OVER");
        menu.SetActive(true);
        Debug.Log("ciao");
    }

    void LevelCompleted()
    {
        SetText("LEVEL COMPLETED");
        menu.SetActive(true);
    }

    void SetText(string text)
    {
        menuText.text = text;
    }

    void OnDestroy()
    {
        GameManager.singleton.OnGameOver -= GameOver;
        GameManager.singleton.OnLevelCompleted -= LevelCompleted;
    }


}
