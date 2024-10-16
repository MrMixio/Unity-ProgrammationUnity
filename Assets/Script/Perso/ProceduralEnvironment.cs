using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralEnvironment : MonoBehaviour
{
    [Header("Chunk Prefabs")]
    public GameObject[] _environmentPrefabs; 
    
    [Header("Chunk Spawn Settings")]
    public int _gridSize = 10; 
    public float _chunkSize = 50f; 
    
    [Header("Chunk Destroyed out of range")]
    public bool _destroyOutOfRangeChunks = true;
    
    [Header("Position Spawn Settings")]
    private Transform _playerTransform; 
    private Dictionary<Vector2Int, GameObject> _loadedChunks = new Dictionary<Vector2Int, GameObject>(); 

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GenerateChunksAroundPlayer();
    }

    private void Update()
    {
        GenerateChunksAroundPlayer();
    }

    private void GenerateChunksAroundPlayer()
    {
        Vector2Int playerChunkCoord = GetChunkCoordFromPosition(_playerTransform.position);
        
        HashSet<Vector2Int> chunksToKeep = new HashSet<Vector2Int>(); //Chunks qui resteront

        for (int x = -_gridSize / 2; x < _gridSize / 2; x++)
        {
            for (int z = -_gridSize / 2; z < _gridSize / 2; z++)
            {
                Vector2Int chunkCoord = new Vector2Int(playerChunkCoord.x + x, playerChunkCoord.y + z);
                chunksToKeep.Add(chunkCoord); 

                if (!_loadedChunks.ContainsKey(chunkCoord)) 
                {
                    LoadChunk(chunkCoord);
                }
            }
        }
        
        // Si bool active alors les chunk or de porté seront détruit (renouvellement de map)
        if (_destroyOutOfRangeChunks)
        {
            List<Vector2Int> chunksToRemove = new List<Vector2Int>();

            foreach (var chunkCoord in _loadedChunks.Keys)
            {
                if (!chunksToKeep.Contains(chunkCoord))
                {
                    chunksToRemove.Add(chunkCoord); 
                }
            }

            foreach (var chunkCoord in chunksToRemove)
            {
                // Appeler la fonction de despawn 
                UnloadChunk(chunkCoord); 
            }
        }
    }

    private Vector2Int GetChunkCoordFromPosition(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x / _chunkSize);
        int z = Mathf.FloorToInt(position.z / _chunkSize);
        return new Vector2Int(x, z);
    }

    private void LoadChunk(Vector2Int coord)
    {
        Vector3 chunkPosition = new Vector3(coord.x * _chunkSize, 0, coord.y * _chunkSize);

        GameObject selectedPrefab = _environmentPrefabs[Random.Range(0, _environmentPrefabs.Length)];
        GameObject newChunk = Instantiate(selectedPrefab, chunkPosition, Quaternion.identity);

        _loadedChunks.Add(coord, newChunk);
    }

    private void UnloadChunk(Vector2Int coord)
    {
        if (_loadedChunks.ContainsKey(coord))
        {
            Destroy(_loadedChunks[coord]); 
            _loadedChunks.Remove(coord); 
        }
    }
    
    // --- Gizmos pour afficher la grille ---
    private void OnDrawGizmos()
    {
        if (_playerTransform == null)
            return;

        Gizmos.color = Color.green;
        Vector2Int playerChunkCoord = GetChunkCoordFromPosition(_playerTransform.position);

        for (int x = -_gridSize / 2; x < _gridSize / 2; x++)
        {
            for (int z = -_gridSize / 2; z < _gridSize / 2; z++)
            {
                Vector2Int chunkCoord = new Vector2Int(playerChunkCoord.x + x, playerChunkCoord.y + z);
                Vector3 chunkPosition = new Vector3(chunkCoord.x * _chunkSize, 0, chunkCoord.y * _chunkSize);
                Gizmos.DrawWireCube(chunkPosition, new Vector3(_chunkSize, 1, _chunkSize));
            }
        }
    }
}
