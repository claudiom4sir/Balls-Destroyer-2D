using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    float maxY; // if this bullet achive this y coordinate, it will be destroyed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("rb is null");
        SetMaxY();
    }

    void SetMaxY()
    {
        maxY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1f)).y;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
        if (rb.position.y >= maxY)
            DestroyBullet();
    }

    void DestroyBullet()
    {
        PlayerWeapon pw = GameManager.singleton.GetPlayer().GetComponent<PlayerWeapon>();
        if (pw == null)
            Debug.LogError("pw is null");
        else
            pw.SetExistsBullet(false);
        Destroy(gameObject);
    }

}
