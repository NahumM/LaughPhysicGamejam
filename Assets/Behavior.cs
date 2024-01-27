using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Behavior : MonoBehaviour
{
    [SerializeField] private Transform[] pointsToGo;
    private NavMeshAgent Agent;
    private Animator Animator;
    [SerializeField] private Rigidbody[] rbToTurn;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();

        // Update is called once per frame
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(DanceCor());
        }
    }

    private IEnumerator DanceCor()
    {
        yield return new WaitForSeconds(1);
        Agent.SetDestination(pointsToGo[0].position);
        Animator.SetFloat("Beh", 1);
        yield return new WaitForSeconds(3);
        Agent.SetDestination(pointsToGo[1].position);
        yield return new WaitForSeconds(2f);
        Agent.SetDestination(pointsToGo[2].position);
        yield return new WaitForSeconds(1);
        foreach (var rb in rbToTurn)
        {
            rb.isKinematic = false;
            rb.AddForce(-rb.transform.right * 500, ForceMode.Acceleration);
        }
    }
}
