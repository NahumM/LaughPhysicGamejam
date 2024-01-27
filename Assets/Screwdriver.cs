using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Screwdriver : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private Rigidbody _rb;
   [SerializeField] private GameObject particles;
   private AudioSource source;


   private void Start()
   {
      source = GetComponent<AudioSource>();
   }


   public void OnDriver()
   {
      _animator.enabled = false;
      _rb.isKinematic = false;
      particles.SetActive(false);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Cross")
      {
         if (!source.isPlaying)
         {
            source.pitch = Random.Range(0.8f, 1.2f);
            source.Play();
         }
         other.GetComponent<CrossScrew>().Screw();
      }
   }
}
