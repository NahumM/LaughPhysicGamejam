using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerCode : MonoBehaviour
{
    
    [SerializeField] private float[] code;

    [SerializeField] private LockerButton[] buttons;


    private bool goingRight;


    private int currentNumber;

    [SerializeField] private GameObject go;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject[] ducks;

    public void CodeNumber(float number)
    {
        goingRight = number == code[currentNumber];

        if (goingRight) currentNumber++;
        else
        {
            currentNumber = 0;
            foreach (var button in buttons)
            {
                button.Highlight(false);
            }
        }

        if (currentNumber == 4)
        {
            Open();
        }
    }

    private void Open()
    {
        foreach (var duck in ducks)
        {
            duck.SetActive(true);
        }

        go.SetActive(false);
       // rb.transform.GetComponent<Collider>().enabled = true;
        //rb.isKinematic = false;
        //rb.AddForce(transform.forward * 400);
       // rb.gameObject.layer = 6;
    }



}
