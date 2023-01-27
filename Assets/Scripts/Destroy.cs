using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    string nom;
    GameObject go;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tapis")
        {
            nom = collision.name;
            go = GameObject.Find(nom);
            Destroy(go);
        }
    }
}
