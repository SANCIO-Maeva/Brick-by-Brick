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

    /*
    * Récupère les entrées tactiles à chaque frame physique.
    * Si l'utilisateur glisse son doigt, on calcule la direction.
    * Le mouvement est appliqué via la vélocité du Rigidbody2D.
    * On limite ensuite la position horizontale du joueur à l'écran.
    */
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
                        /// calcule la distance horizontale glissée ///
                        float deltaX = touch.position.x - _touchStartPos.x;

                        /// convertit le glissement en valeur de déplacement normalisée ///
                        moveInput = Mathf.Clamp(deltaX / Screen.width * 5f, -1f, 1f);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _isDragging = false;
                    break;
            }
        }

        /// applique la vélocité horizontale ///
        Vector2 velocity = new Vector2(moveInput * moveSpeed, _rb.linearVelocity.y);
        _rb.linearVelocity = velocity;

    }
}
