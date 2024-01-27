using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScrew : MonoBehaviour
{
   [SerializeField] private TV tv;
   [SerializeField] private ParticleSystem particles;
   [SerializeField] private Renderer renderer;
   public void Screw()
   {
      tv.Add();
      particles.Play();
      renderer.enabled = false;
   }
}
