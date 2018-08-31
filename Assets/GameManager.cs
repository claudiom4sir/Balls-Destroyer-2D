using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;

    [SerializeField] GameObject wallPrefab;

    void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        DrawWall();
    }

    void DrawWall()
    {

    }

}
