using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{


    [SerializeField] private GameObject[] turnOff;
    [SerializeField] private GameObject[] turnOn;
    [SerializeField] private Animator _animator;

    [SerializeField] private GameObject donut;
    [SerializeField] private GameObject startCamera;
    [SerializeField] private GameObject character;
    public void StartGame()
    {
        foreach (var gm in turnOff)
        {
            gm.SetActive(false);
        }
        foreach (var gm in turnOn)
        {
            gm.SetActive(true);
        }

        StartCoroutine(StartCoroutine());
    }

    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(2);
        _animator.SetBool("start", true);
        yield return new WaitForSeconds(5);
        while (startCamera.transform.position != character.transform.position)
        {
            startCamera.transform.position = Vector3.MoveTowards(startCamera.transform.position,
                character.transform.position, Time.deltaTime * 3);
            yield return null;
        }
        startCamera.SetActive(false);
        character.SetActive(true);
        donut.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
