using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private int clicksToPop = 10;
    public float scaleIncreasePerClick = 0.1f;
    public ScoreManager scoreManager;
    void Awake() 
    {
        clicksToPop = Random.Range(1, 16); // 1 to 15 inclusive
    }
    void OnMouseDown()
    {
        clicksToPop -= 1;

        transform.localScale += Vector3.one * scaleIncreasePerClick;

        if (clicksToPop <= 0)
        {
          if (scoreManager != null) 
        {
            scoreManager.IncreaseScore(Random.Range(5, 15));
        }
        Destroy(gameObject);
        }
    }
}