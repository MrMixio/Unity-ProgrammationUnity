using UnityEngine;

public abstract class Biome
{
    public abstract Color GetColor();
    public abstract void GenerateFeatures(Chunk chunk);
}