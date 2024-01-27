using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] private float satSpeed = 3;

    private IEnumerator SetSaturationSmooth(Material mat)
    {
        float saturation = 0;
        yield return null;
        while (saturation != 3)
        {
            yield return null;
            saturation = Mathf.MoveTowards(saturation, 3, Time.deltaTime * satSpeed);
            mat.SetFloat("_Saturation", saturation);
        }
        while (saturation != 1)
        {
            yield return null;
            saturation = Mathf.MoveTowards(saturation, 1, Time.deltaTime * satSpeed);
            mat.SetFloat("_Saturation", saturation);
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       /* if (Input.GetKeyDown(KeyCode.T))
        {
            var overlap = Physics.OverlapSphere(transform.position, 30);

            foreach (var ovr in overlap)
            {
                var renderers = ovr.GetComponentsInChildren<Renderer>();
                foreach (var renderer in renderers)
                {
                    if (renderer == null) continue;
                    StartCoroutine(SetSaturationSmooth(renderer.material));
                }
               // if (mat == null) continue;
               // StartCoroutine(SetSaturationSmooth(mat.material));
            }
        }*/
    }
}
