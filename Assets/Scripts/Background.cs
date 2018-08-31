using UnityEngine;

public class Background : MonoBehaviour {

    [SerializeField] BoxCollider2D leftWall;
    [SerializeField] BoxCollider2D rightWall;

    void Start()
    {
        DrawWall(leftWall, 0, new Vector3(0f, 0.5f, 0f));
    }

    static void DrawWall(BoxCollider2D collider, float x, Vector3 centerPositionInViewPort)
    {
        Vector3 bottomPosition = Camera.main.ViewportToWorldPoint(new Vector3(x, 0, 0));
        Debug.Log(bottomPosition);
        Vector3 topPosition = Camera.main.ViewportToWorldPoint(new Vector3(x, 1, 0));
        Debug.Log(topPosition);
        collider.size = new Vector2(0.5f, (topPosition.y - bottomPosition.y) / 2);
        Vector3 centerPosition = Camera.main.ViewportToWorldPoint(centerPositionInViewPort);
    }

}
