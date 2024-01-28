using System.Collections;
using UnityEngine;

public class AmbientSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip ambientSound;
    [SerializeField] private Animator animator;
    [SerializeField] private float behaviorThreshold = 1f;
    [SerializeField] private float delayAfterBehReached = 10f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = ambientSound;
        audioSource.loop = true;

        // Start playing the ambient sound
        audioSource.Play();

        // Start monitoring the condition
        StartCoroutine(MonitorCondition());
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void Play()
    {
        audioSource.Play();
    }

    private IEnumerator MonitorCondition()
    {
        bool hasReachedBehThreshold = false;

        // Check the condition in a loop
        while (true)
        {
            // Wait for a short duration before checking the condition again
            yield return new WaitForSeconds(0.5f);

            // Check if the Animator's float parameter "Beh" is greater than or equal to the threshold
            if (animator.GetFloat("Beh") >= behaviorThreshold)
            {
                // Ensure that we only execute this block once
                if (!hasReachedBehThreshold)
                {
                    // Set the flag to true to avoid repeating this block
                    hasReachedBehThreshold = true;

                    // Stop the ambient sound
                    audioSource.Stop();

                    // Wait for the specified delay
                    yield return new WaitForSeconds(delayAfterBehReached);

                    // Restart the ambient sound
                    audioSource.Play();
                }
            }
            else
            {
                // Reset the flag if the condition is not met
                hasReachedBehThreshold = false;
            }
        }
    }
}
