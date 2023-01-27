using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTapis : MonoBehaviour
{
    public bool AtteintLaFin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tapis")
        {
            AtteintLaFin = true;
        }
    }
}
