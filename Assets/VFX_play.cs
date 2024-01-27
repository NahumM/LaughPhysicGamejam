using UnityEngine;
using System.Collections.Generic;

public class VFX_play : MonoBehaviour
{
    public List<ParticleSystem> particles;

    public void OnButtonClick()
    {
        foreach( ParticleSystem particle in particles){
            particle.Play();
        }
    }
}
