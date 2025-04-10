using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public FinishTrigger finishTrigger;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "FinishZone"){
            finishTrigger.GameWin();
        }
    }
}
