using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip[] footstepsSounds; // Array to store different footsteps sounds
    private AudioSource audioSource;
    private bool isWalking;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check if the player is walking (you can modify this based on your movement logic)
        isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (isWalking)
        {
            if (!audioSource.isPlaying)
            {
                // Play footstep sound continuously
                audioSource.clip = GetRandomFootstepSound();
                audioSource.Play();
            }
        }
        else
        {
            // Stop playing sound when not walking
            audioSource.Stop();
        }
    }

    private AudioClip GetRandomFootstepSound()
    {
        if (footstepsSounds.Length > 0)
        {
            return footstepsSounds[Random.Range(0, footstepsSounds.Length)];
        }

        return null;
    }
}
