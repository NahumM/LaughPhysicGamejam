using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private Animator _animator;
    [SerializeField] private SaturationCombo[] satur;
    void Start()
    {
        
    }
    
    [SerializeField] private float satSpeed = 3;

    private IEnumerator SetSaturationSmooth(SaturationCombo combo)
    {
        float saturation = 0;
        while (saturation != 3)
        {
            yield return null;
            saturation = Mathf.MoveTowards(saturation, 3, Time.deltaTime * satSpeed);
            combo.saturation = saturation;
        }
        while (saturation != 1)
        {
            yield return null;
            saturation = Mathf.MoveTowards(saturation, 1, Time.deltaTime * satSpeed);
            combo.saturation = saturation;
        }
        
    }

    private IEnumerator Stats(SaturationCombo combo)
    {
        yield return new WaitForSeconds(9);
        float saturation = combo.saturation;
        _animator.SetFloat("Beh", 2);
        while (saturation != 0)
        {
            yield return null;
            saturation = Mathf.MoveTowards(saturation, 0, Time.deltaTime * satSpeed);
            combo.saturation = saturation;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _volume.weight = 0;
            StartCoroutine(SetSaturationSmooth(satur[0]));
            StartCoroutine(SetSaturationSmooth(satur[1]));
            StartCoroutine(Stats(satur[1]));
        }
    }
}
