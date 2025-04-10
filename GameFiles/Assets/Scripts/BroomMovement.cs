using UnityEngine;

public class BroomMovement : MonoBehaviour
{
    public Rigidbody rb;
    void FixedUpdate()
    {
        rb.AddForce(0,0,10 * Time.deltaTime);
        if(Input.GetKey("d")){
            rb.AddForce(500f * Time.deltaTime,0,0);
        }
        if(Input.GetKey("a")){
            rb.AddForce(-500f * Time.deltaTime,0,0);
        }
        if(Input.GetKey("w")){
             rb.AddForce(0,0,200f * Time.deltaTime);
        }
          if(Input.GetKey("s")){
             rb.AddForce(0,0,-200f * Time.deltaTime);
        }
         if(Input.GetKey(KeyCode.RightArrow)){
            rb.AddForce(500f * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.AddForce(-500f * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
             rb.AddForce(0,0,200f * Time.deltaTime);
        }
          if(Input.GetKey(KeyCode.DownArrow)){
             rb.AddForce(0,0,-200f * Time.deltaTime);
        }

    }
}
