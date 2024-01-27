using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField] private ChessDetect[] detects;

    private bool completed;
    [SerializeField] private Animator _animator;


    private void Update()
    {
        if (completed) return;
        foreach (var detect in detects)
        {
            if (!detect.Detected) return;
        }
        
        Complete();
        
    }

    private void Complete()
    {
        completed = true;
        _animator.enabled = true;
        Debug.Log("COMPLETER");
    }
}
