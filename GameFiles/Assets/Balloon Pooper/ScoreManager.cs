using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public float endDelay = 3f;

    public GameObject wandPrefab; // The wand object to spawn
    public Transform spawnPoint; // Where the wand should appear

    private bool hasSpawned = false; // Ensures the wand spawns only once
    void SpawnWand()
    {
        Instantiate(wandPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void Start()
    {
        UpdateScoreText();
    }
    
    public void IncreaseScore(int amount)
    {
        score += amount;

        Debug.Log(score);
        UpdateScoreText();
        if (score > 125) 
        {
        FinishGame();
        scoreText.text = "You Win";
        return;
        }
    }

    void UpdateScoreText ()
    {
        
        if(score > 125){
            Debug.Log("Going her");
            FinishGame();
            scoreText.text = "You Win";
        }
        else{
            scoreText.text = "Score: " + score;
        }
    }
    void FinishGame()
    {
        
            SpawnWand();
            Debug.Log("Game won");
            Invoke("NextScene",endDelay);
     
    }
    public void NextScene(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
}  