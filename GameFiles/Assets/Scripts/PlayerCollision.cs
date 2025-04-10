using UnityEngine;

namespace broomGame{
    public class PlayerCollision : MonoBehaviour
    {
        public BroomMovement broomMovement;
        void OnCollisionEnter(Collision collisionInfo)
        {
            if(collisionInfo.collider.tag == "Obstacle"){
                broomMovement.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }        
            if(collisionInfo.collider.tag == "Finish"){
                broomMovement.enabled = false;
                FindObjectOfType<GameManager>().FinishLine();
            }
        }
    }
}