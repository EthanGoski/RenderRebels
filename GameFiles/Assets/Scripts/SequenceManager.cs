using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SequenceManager : MonoBehaviour
{
    public List<int> sequence = new List<int>(); // Correct sequence
    public int sequenceLength = 3; // Starting sequence length
    public float delayBetweenLights = 1f; // Delay between each dot lighting up
    public GameObject[] dots; // Array holding dot GameObjects
    public GameObject wand; // Wand reward

    public bool playerTurn = false;
    private List<int> playerInput = new List<int>();

    void Start()
    {
        wand.SetActive(false); // Hide wand at the start
        StartNewRound();
    }

    public void StartNewRound()
    {
        playerTurn = false; // Disable player input
        sequence.Clear();
        playerInput.Clear();

        // Generate a new sequence
        for (int i = 0; i < sequenceLength; i++)
        {
            sequence.Add(Random.Range(0, dots.Length));
        }

        StartCoroutine(ShowSequence());
    }

    IEnumerator ShowSequence()
    {
        yield return new WaitForSeconds(1f); // Small delay before sequence starts

        foreach (int index in sequence)
        {
            Renderer dotRenderer = dots[index].GetComponent<Renderer>();
            Color originalColor = dotRenderer.material.color;

            dotRenderer.material.color = Color.yellow; // Light up
            yield return new WaitForSeconds(0.5f);

            dotRenderer.material.color = originalColor; // Reset color
            yield return new WaitForSeconds(delayBetweenLights);
        }

        playerTurn = true; // Enable player input
    }

    public void PlayerPress(int index)
    {
        if (!playerTurn) return; // Ignore input if sequence is still playing

        playerInput.Add(index);
        StartCoroutine(FlashDot(index));
    
        // Check if full sequence is completed
        if (playerInput.Count == sequence.Count)
        {
            // If full sequence is correct, show green and reward wand
            if (IsSequenceCorrect())
            {
                Debug.Log("Correct Sequence! Rewarding wand.");
                StartCoroutine(ShowCorrectSequence());
            }
            else
            {
                Debug.Log("Wrong Sequence! Restarting...");
                StartCoroutine(ShowWrongSequence());
            }
        }
    }

    bool IsSequenceCorrect()
    {
        for (int i = 0; i < sequence.Count; i++)
        {
            if (playerInput[i] != sequence[i])
                return false;
        }
        return true;
    }

    IEnumerator ShowCorrectSequence()
    {
        playerTurn = false; // Stop further inputs

        // Turn all dots green
        SetDotsColor(Color.green);

        // Grant wand reward
        wand.SetActive(true);
        Debug.Log("Congratulations! You received a magical wand.");

        yield return new WaitForSeconds(1f);

        // Blink all dots green 5 times
        for (int i = 0; i < 5; i++)
        {
            SetDotsColor(Color.black);
            yield return new WaitForSeconds(0.3f);
            SetDotsColor(Color.green);
            yield return new WaitForSeconds(0.3f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Game Over: Player has won!");
    }

    IEnumerator ShowWrongSequence()
    {
        playerTurn = false; // Disable input

        // Turn all dots red
        SetDotsColor(Color.red);
        yield return new WaitForSeconds(1f);

        ResetDotColors();
        StartNewRound(); // Restart round
    }

    void ResetDotColors()
    {
        SetDotsColor(Color.black); // Reset to black
    }

    void SetDotsColor(Color color)
    {
        foreach (GameObject dot in dots)
        {
            dot.GetComponent<Renderer>().material.color = color;
        }
    }
    IEnumerator FlashDot(int index)
    {
    Renderer dotRenderer = dots[index].GetComponent<Renderer>();
    Color originalColor = dotRenderer.material.color;

    dotRenderer.material.color = Color.yellow; // Light up
    yield return new WaitForSeconds(0.5f); // Wait for half a second

    dotRenderer.material.color = originalColor; // Reset color
    }
}