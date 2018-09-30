using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    float maxY; // if this bullet achive this y coordinate, it will be destroyed
    GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.singleton;
    }

    void Start()
    {
        SetMaxY();   
    }

    void SetMaxY()
    {
        maxY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1f)).y;
    }

    void FixedUpdate()
    {
        if (gameManager.IsGameOver() || gameManager.IsLevelCompleted() || gameManager.IsGameInPause())
            return;
        rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
        if (rb.position.y >= maxY)
            DestroyBullet();
    }

    public void DestroyBullet()
    {
        PlayerWeapon pw = gameManager.GetPlayer().GetComponent<PlayerWeapon>();
        if (pw == null)
            Debug.LogError("pw is null");
        pw.SetExistsBullet(false);
        Destroy(gameObject);
    }

}
