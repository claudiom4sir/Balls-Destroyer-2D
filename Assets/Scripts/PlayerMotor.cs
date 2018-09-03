using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField] float speed = 10f;
    Rigidbody2D rb;
    float xDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("rb is null");
    }

    public void SetDirection(float _xDirection)
    {
        xDirection = _xDirection;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * xDirection* speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball" && !GameManager.singleton.GetGameOver())
            GameManager.singleton.GameOver();
    }

}
