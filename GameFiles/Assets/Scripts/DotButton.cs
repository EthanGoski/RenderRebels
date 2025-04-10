using UnityEngine;
public class DotButton : MonoBehaviour
{
    public int dotIndex;
    private SequenceManager sequenceManager;

    void Start()
    {
        sequenceManager = FindObjectOfType<SequenceManager>();
    }

    void OnMouseDown()
    {
        if(sequenceManager.playerTurn)
        {
            Debug.Log("Dot Clicked: "+dotIndex);
            sequenceManager.PlayerPress(dotIndex);
        }
        
    }
}