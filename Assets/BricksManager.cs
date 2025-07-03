using UnityEngine;
using UnityEngine.SceneManagement;

public class BricksManager : MonoBehaviour
{
    public GameObject[] brickPrefabs;

    public int rows = 5;
    public int columns = 8;
    public float spacing = 0.2f;

    public Vector2 startPosition = new Vector2(-7f, 4f);
    public Vector2 brickSize = new Vector2(1.5f, 0.6f);

    void Start()
    {
        GenerateBricks();
    }

    /*
    * Génère une grille de briques au lancement du jeu.
    * Chaque brique est choisie aléatoirement parmi les prefabs disponibles.
    * Les positions sont calculées en fonction du nombre de colonnes, lignes, espacement et taille.
    */
    void GenerateBricks()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                /// calcule la position de la brique ///
                Vector2 spawnPos = new Vector2(
                    startPosition.x + col * (brickSize.x + spacing),
                    startPosition.y - row * (brickSize.y + spacing)
                );

                /// sélectionne un prefab de brique au hasard ///
                int randomIndex = Random.Range(0, brickPrefabs.Length);
                GameObject selectedBrick = brickPrefabs[randomIndex];

                /// instancie la brique dans la scène, en tant qu'enfant de ce GameObject ///
                Instantiate(selectedBrick, spawnPos, Quaternion.identity, transform);
            }
        }
    }
}
