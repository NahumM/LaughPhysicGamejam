using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerButton : MonoBehaviour
{
    public Text text;

    public LockerCode code;
    // Start is called before the first frame update
    public void Highlight(bool asnwer)
    {
        text.color = asnwer ? Color.red : Color.white;
    }

    public void Push()
    {
        code.CodeNumber(float.Parse(gameObject.name));
        Highlight(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
