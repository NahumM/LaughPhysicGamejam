using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class Behavior : MonoBehaviour
{
    [SerializeField] private Transform[] pointsToGo;
    private NavMeshAgent Agent;
    private Animator Animator;
    [SerializeField] private Rigidbody[] rbToTurn;
    [SerializeField] private UnityEvent buttonPush;
    [SerializeField] private VolumeControl _volumeControl;
    [SerializeField] private GameObject opener;
    [SerializeField] private SaturationCombo _sat;
    [SerializeField] private AudioClip contactSound;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        // Update is called once per frame
    }

    public void OnButtonPush()
    {
        buttonPush?.Invoke();
    }

    public void StartScenario()
    {
        StartCoroutine(DanceCor());
        _volumeControl.StartScenario();
    }
    

private IEnumerator DanceCor()
{
    yield return new WaitForSeconds(1);
    Agent.SetDestination(pointsToGo[0].position);
    Animator.SetFloat("Beh", 1);
    yield return new WaitForSeconds(3);
    opener.SetActive(true);
    Agent.SetDestination(pointsToGo[1].position);
    yield return new WaitForSeconds(2f);
    Agent.SetDestination(pointsToGo[2].position);
    yield return new WaitForSeconds(1);
    
    foreach (var rb in rbToTurn)
    {
        rb.isKinematic = false;
        rb.AddForce(-rb.transform.right * 500, ForceMode.Acceleration);

        // Wait for a short duration before playing the sound
        yield return new WaitForSeconds(0.5f);

        // Check if the Rigidbody has an AudioSource component
        AudioSource audioSource = rb.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If not, add an AudioSource component
            audioSource = rb.gameObject.AddComponent<AudioSource>();
        }

        // Play the contact sound
        audioSource.clip = contactSound;
        audioSource.Play();
    }

    yield return new WaitForSeconds(1.5f);
    
    foreach (var rb in rbToTurn)
    {
        rb.transform.GetComponent<Collider>().enabled = false;
    }
    
    yield return new WaitForSeconds(1.5f);
    
    foreach (var rb in rbToTurn)
    {
        rb.gameObject.SetActive(false);
    }

    // Uncomment the line below to set saturation to 0
    // _sat.saturation = 0;
}
}
