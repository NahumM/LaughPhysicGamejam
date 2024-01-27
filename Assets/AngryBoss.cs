using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBoss : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer renderer;
    private float vlau;
    private bool back;
    void Start()
    {
        renderer.SetBlendShapeWeight(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!back)
        {
            vlau = Mathf.MoveTowards(vlau, 1, Time.deltaTime * 8);
            if (vlau >= 1) back = true;
        }

        if (back)
        {
            vlau = Mathf.MoveTowards(vlau, 0, Time.deltaTime * 2);
            if (vlau <= 0) back = false;
        }
        renderer.SetBlendShapeWeight(0, vlau);
    }
}
