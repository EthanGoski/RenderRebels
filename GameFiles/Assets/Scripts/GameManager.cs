using UnityEngine;
using UnityEngine.SceneManagement;

namespace broomGame{
    public class GameManager : MonoBehaviour
    {
        bool gameHasEnded = false;

        bool finishLine = false;
        public float restartDelay = 2f;

        public float endDelay = 3f;
        public GameObject wandPrefab; // The wand object to spawn
        public Transform spawnPoint; // Where the wand should appear

        private bool hasSpawned = false; // Ensures the wand spawns only once
        void SpawnWand()
        {
           Vector3 spawnPosition = spawnPoint.position + Vector3.up * 2f; // Move the wand up
        GameObject wandInstance = Instantiate(wandPrefab, spawnPosition, spawnPoint.rotation);

        // Add a light component to the wand
        Light wandLight = wandInstance.AddComponent<Light>();
        wandLight.type = LightType.Point; // You can change this to Spot or Directional if needed
        wandLight.color = Color.yellow;   // Change the color of the light
        wandLight.intensity = 5f;         // Adjust intensity as needed
        wandLight.range = 10f;            // Adjust range to fit the effect
        }
        public void EndGame()
        {
            if(gameHasEnded == false){
                gameHasEnded = true;
                Debug.Log("End Game");
                Invoke("Restart", restartDelay);
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void FinishLine()
        {
            SpawnWand();
            Invoke("NextScene", endDelay);
        }

        public void NextScene(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}