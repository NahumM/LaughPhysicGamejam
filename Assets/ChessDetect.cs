using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessDetect : MonoBehaviour
{

    private AudioSource source;
    public bool Detected;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Detect(bool answer)
    {
        Detected = answer;
        if (answer && !source.isPlaying) source.Play();
    }
}
