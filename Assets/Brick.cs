using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitPoints = 1;
    public int points = 5; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitPoints--;

            if (hitPoints <= 0)
            {
                DestroyBrick();
            }
        }
    }

    void DestroyBrick()
    {
        // Ajoute les points au score
        GameManager.Instance.UpdateScore(points);
        Destroy(gameObject);
    }
}
