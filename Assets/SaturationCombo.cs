using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturationCombo : MonoBehaviour
{
    [SerializeField] private List<Material> materialsToSaturate;
    public float saturation = 1;
    void Start()
    {
        var renderers = GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            foreach (var mat in renderer.materials)
            {
                materialsToSaturate.Add(mat);
            }
        }
        foreach (var mat in materialsToSaturate)
        {
            mat.SetFloat("_Saturation", saturation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var mat in materialsToSaturate)
        {
            mat.SetFloat("_Saturation", saturation);
        }
    }
}
