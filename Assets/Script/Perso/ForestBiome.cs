using UnityEngine;

public class ForestBiome : Biome
{
    public override Color GetColor() => Color.green;

    public override void GenerateFeatures(Chunk chunk)
    {
        // Ajouter des fonctionnalités spécifiques au biome forestier ici
    }
}