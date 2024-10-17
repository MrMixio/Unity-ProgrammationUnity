using UnityEngine;

public class DesertBiome : Biome
{
    public override Color GetColor() => Color.yellow;

    public override void GenerateFeatures(Chunk chunk)
    {
        // Ajouter des fonctionnalités spécifiques au biome désertique ici
    }
}