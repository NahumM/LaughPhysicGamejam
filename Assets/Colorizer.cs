using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorizer : MonoBehaviour
{
    [SerializeField] private float satSpeed = 3;
    private Rigidbody rb;
    [SerializeField] private ParticleSystem pS;
    [SerializeField] private MeshRenderer renderer;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.isKinematic) return;
        
       if (!pS.isPlaying)
            pS.Play();

       var colliders = Physics.OverlapSphere(transform.position, 14f);

       foreach (var collider in colliders)
       {
           if (collider.gameObject.name == "Sergey")
           {
               Debug.Log(gameObject.name);
               collider.GetComponent<Behavior>().StartScenario();
           }
           var renderers  = collider.transform.GetComponentsInChildren<Renderer>();
           foreach (var renderer in renderers)
           {
               StartCoroutine(SetSaturationSmooth(renderer.material));
           }
       }

       renderer.enabled = false;
       rb.isKinematic = true;
       //StartCoroutine(SetSaturationSmooth())
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
