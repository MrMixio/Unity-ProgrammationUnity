using UnityEngine;

[System.Serializable]
public class Chunk
{
    public Vector2Int Coordinates { get; private set; }
    public BiomeType Biome { get; private set; }
    public int PropagationLevel { get; private set; }
    
    [SerializeField] public float Height { get; private set; } // Ajout de la hauteur

    public Chunk(Vector2Int coordinates)
    {
        Coordinates = coordinates;
    }

    public void SetBiome(BiomeType biome, int level, float height)
    {
        Biome = biome;
        PropagationLevel = level;
        Height = height; // Stockage de la hauteur
    }
    
}