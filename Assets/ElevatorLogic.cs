using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLogic : MonoBehaviour
{
    [SerializeField] private Animator doors;

    [SerializeField] private GameObject[] turnOff;

    [SerializeField] private GameObject bossRoom;

    [SerializeField] private AudioClip[] sounds;

    [SerializeField] private AudioSource sourceToTurn;

    [SerializeField] private AudioSource source;

    [SerializeField] private GameObject finalScreen;
    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            source.Stop();
            source.clip = sounds[0];
            source.Play();
            doors.SetFloat("Beh", 1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Starting();
        }
    }


    public void Starting()
    {
        StartCoroutine(Waiting());
    }


    private IEnumerator Waiting()
    {
        doors.SetFloat("Beh", 2);
        source.Stop();
        source.clip = sounds[0];
        source.Play();
        yield return new WaitForSeconds(1.5f);
        source.Stop();
        source.clip = sounds[1];
        source.Play();
        foreach (var trn in turnOff)
        {
            trn.SetActive(false);
        }
        yield return new WaitForSeconds(4f);
        sourceToTurn.enabled = false;
        bossRoom.SetActive(true);
        source.Stop();
        source.clip = sounds[2];
        source.Play();
        yield return new WaitForSeconds(1f);
        doors.SetFloat("Beh", 1);
        yield return new WaitForSeconds(2);
        finalScreen.SetActive(true);
    }
}
