using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private Rigidbody _rb;
   [SerializeField] private GameObject particles;


   public void OnDriver()
   {
      _animator.enabled = false;
      _rb.isKinematic = false;
      particles.SetActive(false);
   }
}
