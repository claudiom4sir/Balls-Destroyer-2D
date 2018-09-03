using UnityEngine;

public class Ball : MonoBehaviour {

    Rigidbody2D rb;
    [SerializeField] GameObject nextBall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("rb is null");
        AddInitialForce();
    }

    void AddInitialForce()
    {
        float x = Random.Range(0.5f, 1f);
        //float y = Random.Range(0.5f, 1f);
        float factor = Random.Range(0f, 1f);
        if (factor <= 0.5f)
            factor = -1f;
        else
            factor = 1f;
        Vector2 force = new Vector2(x * factor, 1f) * 5f;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public GameObject GetNextBall()
    {
        return nextBall;
    }




}
