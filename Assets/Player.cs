using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float limitX = 8f;
    private Rigidbody2D _rb;

    private Vector2 _touchStartPos;
    private bool _isDragging = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveInput = 0f;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPos = touch.position;
                    _isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        float deltaX = touch.position.x - _touchStartPos.x;
                        moveInput = Mathf.Clamp(deltaX / Screen.width * 5f, -1f, 1f); // Normalise et limite
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _isDragging = false;
                    break;
            }
        }

        Vector2 velocity = new Vector2(moveInput * moveSpeed, _rb.linearVelocity.y);
        _rb.linearVelocity = velocity;

        // Limite la position horizontale
        float clampedX = Mathf.Clamp(transform.position.x, -limitX, limitX);
        transform.position = new Vector2(clampedX, transform.position.y);
    }
}
