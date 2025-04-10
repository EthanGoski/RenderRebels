using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public float endDelay = 3f;
    public GameObject wandPrefab; // The wand object to spawn
    public Transform spawnPoint; // Where the wand should appear

    private bool hasSpawned = false; // Ensures the wand spawns only once
    private void SpawnWand()
    {
        Instantiate(wandPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Spawning Wand");
    }
    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (!hasSpawned) // If player enters the area
        {
            Debug.Log("Hit Wand");
            GameWin();
            hasSpawned = true; // Prevents multiple spawns
        }
    }
    public void GameWin(){
        SpawnWand();
        Debug.Log("Game Win?");
        Invoke("NextScene",endDelay);
        }
    public void NextScene(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
}