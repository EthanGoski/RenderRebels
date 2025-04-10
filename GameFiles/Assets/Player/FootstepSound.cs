using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip[] footstepClips;
    public float stepInterval = 0.5f; // Time between steps

    private CharacterController controller;
    private float stepTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        stepTimer = stepInterval;
    }

    void Update()
    {
        if (controller.isGrounded && (controller.velocity.magnitude > 0.1f))
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = stepInterval;
        }
    }

    void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length); // Randomize sounds
            footstepSource.PlayOneShot(footstepClips[index]);
        }
    }
}
