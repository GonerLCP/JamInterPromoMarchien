using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curseur : MonoBehaviour
{
    private void OnMouseOver()
    {
        print("Ah");
        if (Input.GetMouseButtonDown(0))
        {
            print("1");
        }
        else
        {
            print("0");
        }
    }
}
