using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float limitX = 8f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(moveInput * moveSpeed, 0f);
        _rb.linearVelocity = velocity;

        // Limite la position horizontale
        float clampedX = Mathf.Clamp(transform.position.x, -limitX, limitX);
        transform.position = new Vector2(clampedX, transform.position.y);
    }
}
