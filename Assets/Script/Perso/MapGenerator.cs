using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int mapWidth = 10;
    [SerializeField] private int mapHeight = 10;
    public Chunk[,] chunk;

    void Start()
    {
        chunk = new Chunk[mapWidth, mapHeight];
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector2Int coord = new Vector2Int(x, y);
                chunk[x, y] = new Chunk(coord);
                
                // Détermination du type de biome
                BiomeType biomeType = DetermineBiomeType(coord);
                
                // Génération de la hauteur
                float height = GenerateHeight(coord); 

                // Assignation du biome et de la hauteur au chunk
                chunk[x, y].SetBiome(biomeType, 1, height);
            }
        }
    }

    private float GenerateHeight(Vector2Int coord)
    {
        // Utilise le bruit Perlin pour générer une hauteur
        return Mathf.PerlinNoise(coord.x * 0.1f, coord.y * 0.1f) * 10; // Ajuste le facteur de multiplication pour la hauteur souhaitée
    }

    private BiomeType DetermineBiomeType(Vector2Int coord)
    {
        float noiseValue = Mathf.PerlinNoise(coord.x * 0.1f, coord.y * 0.1f); // Ajuste l'échelle pour varier le bruit
        if (noiseValue < 0.3f)
            return BiomeType.Desert;
        else if (noiseValue < 0.6f)
            return BiomeType.Forest;
        else
            return BiomeType.Mountain;
    }
}

