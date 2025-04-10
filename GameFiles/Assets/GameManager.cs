using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
     public float endDelay = 3f;
    public GameObject wandPrefab; // The wand object to spawn
    public Transform spawnPoint; // Where the wand should appear
    public Vector3 wandSpawn = new Vector3(-95, 0, 34);
    public Quaternion rotation = new Quaternion(1, 1, 1, 1);
    private bool hasSpawned = false; // Ensures the wand spawns only once
    public void SpawnWand()
    {
        Instantiate(wandPrefab, spawnPoint.position,spawnPoint.rotation);
    }

    
}

