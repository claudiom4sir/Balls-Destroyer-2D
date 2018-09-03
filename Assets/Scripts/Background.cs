using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;

    void Start()
    {
        DrawWall(leftWall, 0, new Vector2(0, 0.5f));
        DrawWall(rightWall, 1, new Vector2(1, 0.5f));
    }

    static void DrawWall(GameObject wall, float x, Vector2 centerPositionInViewPort)
    {
        Vector2 bottomPosition = Camera.main.ViewportToWorldPoint(new Vector2(x, 0));
        Vector2 topPosition = Camera.main.ViewportToWorldPoint(new Vector2(x, 1));
        wall.transform.localScale = new Vector2(0.5f, topPosition.y - bottomPosition.y);
        Vector2 centerPosition = Camera.main.ViewportToWorldPoint(centerPositionInViewPort);
        wall.transform.position = centerPosition;
    }

}
