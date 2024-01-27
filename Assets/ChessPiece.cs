using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{

   private void OnTriggerEnter(Collider collision)
   {
      if (collision.gameObject.layer == 12)
      {
         Debug.Log("Test");
         collision.transform.GetComponent<ChessDetect>().Detect(true);
      }
   }
   
   private void OnTriggerExit(Collider collision)
   {
      if (collision.gameObject.layer == 12)
      {
         Debug.Log("Test2");
         collision.transform.GetComponent<ChessDetect>().Detect(false);
      }
   }
}
