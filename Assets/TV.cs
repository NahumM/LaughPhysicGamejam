using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    private AudioSource source;
    private int timesLeft = 4;
    private Rigidbody rb;
    [SerializeField] private SaturationCombo combo;
    [SerializeField] private SaturationCombo combo1;
    [SerializeField] private SaturationCombo combo2;
    [SerializeField] private SaturationCombo combo3;

    [SerializeField] private Animator[] Behs;
    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    public void Add()
    {
        timesLeft--;

        if (timesLeft <= 0)
        {
            EndActions();
        }
    }
    
    private IEnumerator SetSaturationSmooth(SaturationCombo combo)
    {
        float saturation = 0;
        while (saturation != 3)
        {
            yield return null;
            saturation = Mathf.MoveTowards(saturation, 3, Time.deltaTime * 3);
            combo.saturation = saturation;
        }
        while (saturation != 1)
        {
            yield return null;
            saturation = Mathf.MoveTowards(saturation, 1, Time.deltaTime * 3);
            combo.saturation = saturation;
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            EndActions();
        }
    }

    private void EndActions()
    {
        rb.isKinematic = false;
        source.Stop();
        rb.AddTorque(transform.forward * 50);
        StartCoroutine(SetSaturationSmooth(combo));
        StartCoroutine(SetSaturationSmooth(combo1));
        StartCoroutine(SetSaturationSmooth(combo2));
        StartCoroutine(SetSaturationSmooth(combo3));
        foreach (var beh in Behs)
        {
            beh.SetFloat("Beh", 1);
        }
    }

}
