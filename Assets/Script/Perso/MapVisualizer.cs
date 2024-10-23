using UnityEngine;

public class MapVisualizer : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public float chunkSize = 1f;

    // void OnDrawGizmos()
    // {
    //     if (mapGenerator == null)
    //         return;
    //
    //     foreach (var chunk in mapGenerator.chunk)
    //     {
    //         Gizmos.color = GetColorForBiome(chunk.Biome);
    //         // Utilise la hauteur pour positionner le cube
    //         Gizmos.DrawCube(new Vector3(chunk.Coordinates.x * chunkSize, chunk.Height * chunkSize / 2, chunk.Coordinates.y * chunkSize), Vector3.one * chunkSize);
    //     }
    // }
    //
    //
    // private Color GetColorForBiome(BiomeType biome)
    // {
    //     switch (biome)
    //     {
    //         case BiomeType.Desert:
    //             return Color.yellow;
    //         case BiomeType.Forest:
    //             return Color.green;
    //         case BiomeType.Mountain:
    //             return Color.gray;
    //         default:
    //             return Color.white;
    //     }
    // }

}