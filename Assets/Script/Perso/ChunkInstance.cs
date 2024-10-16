using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkInstance : MonoBehaviour
{
    [Header("Level Design Elements")]
    public GameObject[] _ldPrefabs; 
    
    [Header("Element On chunk")]
    public int _maxElementsPerChunk = 1; 
    public Vector3 _areaSize = new Vector3(5f, 0f, 5f); 

    [Header("Random Rotation Settings")]
    public bool _randomizeRotation = true; 
    public Vector3 _rotationMin = new Vector3(0f, 0f, 0f); 
    public Vector3 _rotationMax = new Vector3(0f, 360f, 0f); 

    [Header("Spawn Probability")]
    [Range(0f, 1f)]
    // peut être utiliser pour faire des sytème de rareté sur certain chunk
    public float _spawnProbability = 0.8f;
    
    private List<GameObject> _spawnedElements = new List<GameObject>(); 

    void Start()
    {
        GenerateRandomElements();
    }

    #region Generation random
    void GenerateRandomElements()
    {
        if (Random.value > _spawnProbability)
        {
            // Petit Random pour avoir la possibilité de ne rien généré 
            return;
        }
        
        int numElements = Random.Range(1, _maxElementsPerChunk + 1); 
        for (int i = 0; i < numElements; i++)
        {

            GameObject randomPrefab = _ldPrefabs[Random.Range(0, _ldPrefabs.Length)];

            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-_areaSize.x / 2, _areaSize.x / 2),
                Random.Range(0, _areaSize.y),
                Random.Range(-_areaSize.z / 2, _areaSize.z / 2)
            );

            Quaternion randomRotation = Quaternion.identity; 
            if (_randomizeRotation)
            {
                float randomRotX = Random.Range(_rotationMin.x, _rotationMax.x);
                float randomRotY = Random.Range(_rotationMin.y, _rotationMax.y);
                float randomRotZ = Random.Range(_rotationMin.z, _rotationMax.z);
                
                randomRotation = Quaternion.Euler(randomRotX, randomRotY, randomRotZ);
            }

            GameObject spawnedElement = Instantiate(randomPrefab, randomPosition, randomRotation, transform);

            _spawnedElements.Add(spawnedElement);
        }
    }
    #endregion
    
}
