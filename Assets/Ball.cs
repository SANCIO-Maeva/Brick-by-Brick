using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public Transform paddle;

    private Rigidbody2D rb;
    private bool launched = false;
    private Vector3 offset;
    private float minX, maxX, maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offset = transform.position - paddle.position;
        rb.isKinematic = true;

        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = -bounds.x;
        maxX = bounds.x;
        maxY = bounds.y;
    }

    void Update()
    {
        if (!launched)
        {
            transform.position = paddle.position + offset;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0)
                Launch();
        }

        if (transform.position.y < -6f)
            ResetBall();
    }

    void FixedUpdate()
    {
        if (!launched) return;

        Vector2 v = rb.linearVelocity;

        if ((transform.position.x <= minX && v.x < 0) || (transform.position.x >= maxX && v.x > 0))
            v.x *= -1;

        if (transform.position.y >= maxY && v.y > 0)
            v.y *= -1;

        rb.linearVelocity = v.normalized * speed;
    }

    void Launch()
    {
        launched = true;
        rb.isKinematic = false;
        rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1f).normalized * speed;
    }

void ResetBall()
{
    launched = false;
    rb.linearVelocity = Vector2.zero;
    rb.isKinematic = true;

    if (GameManager.Instance != null)
    {
        GameManager.Instance.UpdateHealth(-1);
    }

    transform.position = paddle.position + offset;
}

}
