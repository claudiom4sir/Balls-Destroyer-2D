using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField] float speed = 10f;
    Rigidbody2D rb;
    float xDirection;

    void Awake()
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
        if (GameManager.singleton.IsGameOver() || GameManager.singleton.IsLevelCompleted())
            return;

        // if _xDirection is 1, player moves on right, otherwise (-1) it moves on left
        rb.MovePosition(rb.position + Vector2.right * xDirection* speed * Time.fixedDeltaTime);
    }

    void Update() // used only to test on pc
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            SetDirection(-1);
        else if (Input.GetKey(KeyCode.RightArrow))
            SetDirection(1);
        else
            SetDirection(0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.singleton.IsGameOver() || GameManager.singleton.IsLevelCompleted())
            return;
        if (collision.collider.tag == "Ball")
            GameManager.singleton.GameOver();
    }

}
