using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject plotPrefab;   // <-- this field
    public int width = 5;
    public int height = 5;
    public float cellSize = 1f;

    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * cellSize, y * cellSize, 0);
                Instantiate(plotPrefab, pos, Quaternion.identity);
            }
        }
    }
}