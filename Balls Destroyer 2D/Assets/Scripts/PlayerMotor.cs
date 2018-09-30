using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMotor : MonoBehaviour {

    [SerializeField] float speed = 10f;
    Rigidbody2D rb;
    float xDirection;
    GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.singleton;
    }

    void FixedUpdate()
    {
        if (gameManager.IsGameOver() || gameManager.IsLevelCompleted() || gameManager.IsGameInPause())
            return;
        xDirection = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * xDirection* speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.IsGameOver() || gameManager.IsLevelCompleted() || gameManager.IsGameInPause())
            return;
        if (collision.collider.tag == "Ball")
            GameManager.singleton.GameOver();
    }

}
