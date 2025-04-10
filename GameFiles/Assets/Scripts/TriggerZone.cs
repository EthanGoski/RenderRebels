using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public SequenceManager sequenceManager; // Reference to the SequenceManager script

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has entered the trigger zone!"); // Debugging message
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Ensure the SequenceManager is assigned
            if (sequenceManager != null)
            {
                // Start the mini-game by calling the StartNewRound method
                sequenceManager.StartNewRound();
                Debug.Log("Trigger activated, mini-game started.");
            }
            else
            {
                Debug.LogError("SequenceManager not assigned to TriggerZone script!");
            }
        }
    }
}
