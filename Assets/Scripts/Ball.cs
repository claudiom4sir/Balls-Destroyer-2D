using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] GameObject nextBallPrefab;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)   
            Debug.LogError("rb is null");
    }

    public void AddInitialForce()
    {
        float factor = Random.Range(0f, 1f);
        if (factor <= 0.5f)
            factor = -1f;
        else
            factor = 1f;
        Vector2 force = new Vector2(factor, 0f) * 5f;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    void AddForce(int x)
    {
        Vector2 force = new Vector2(x, 0f) * 5f;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public GameObject GetNextBall()
    {
        return nextBallPrefab;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.singleton.IsGameOver() || GameManager.singleton.IsLevelCompleted())
            return;
        if (collision.collider.tag == "Bullet") {
            Bullet bullet = collision.collider.GetComponent<Bullet>();
            if (bullet == null)
                Debug.LogError("bullet is null");
            bullet.DestroyBullet();
            NextBall();
        }
    }

    void NextBall()
    {
        if (nextBallPrefab != null)
        {
            GameObject lBall = Instantiate(nextBallPrefab, transform.position, Quaternion.identity);
            GameObject rBall = Instantiate(nextBallPrefab, transform.position, Quaternion.identity);
            lBall.GetComponent<Ball>().AddForce(-1);
            rBall.GetComponent<Ball>().AddForce(1);
            BallsManager.singleton.UpdateBallsInGame("+");
        }
        else
            BallsManager.singleton.UpdateBallsInGame("-");
        Destroy(gameObject);
    }

}
