using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTest : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms;
    [SerializeField] private TrailRenderer trail;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _transforms.Length; i++)
        {
            if (trail.positionCount >= 0)
            {
                
            }
            trail.SetPosition(i, _transforms[i].position);
        }
    }
}
