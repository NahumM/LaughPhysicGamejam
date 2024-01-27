using UnityEngine;

public class JumpSoundPlayer : MonoBehaviour
{
    public AudioClip jumpSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play jump sound
            audioSource.clip = jumpSound;
            audioSource.PlayOneShot(jumpSound);
        }
    }
}
