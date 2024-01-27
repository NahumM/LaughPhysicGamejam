using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessDetect : MonoBehaviour
{

    public bool Detected;


    public void Detect(bool answer)
    {
        Detected = answer;
    }
}
